using Connected.Caching;
using Connected.Collections.Queues;
using Connected.Entities;
using Connected.Logictics.Stock.Aggregations;
using Connected.Logistics.Types.SerialNumbers;
using Connected.Logistics.Types.WarehouseLocations;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock.Ops;

internal sealed class UpdateStock(IStorageProvider storage, ICacheContext cache, IEventService events, IStockService stock,
	ISerialNumberService serials, IQueueService queue, IWarehouseLocationService locations)
	: ServiceFunction<IUpdateStockDto, long>
{
	private IStockService Stock { get; } = stock;
	private bool IsLeaf { get; set; }

	protected override async Task<long> OnInvoke()
	{
		/*
		 * We need this info for queueing aggregations.
		 */
		var item = await locations.Select(Dto.CreatePrimaryKey(Dto.Location)) ?? throw new NullReferenceException($"IStockLocation not found ({Dto.Location})");

		IsLeaf = item.ItemCount == 0;
		/*
		 * Validators should validate the existence. Serials don't get deleted.
		 */
		if (await serials.Select(Dto.CreatePrimaryKey(Dto.Serial)) is not ISerialNumber serial)
			return 0;
		/*
		 * Ensure the stock record exists.
		 */
		var stock = await StockUtils.Ensure(storage, Stock, serial.AsDto<IEntityDto, long>());
		/*
		 * Now we must check if the stock item exists for the specified serial and
		 * warehouse location. If so we'll only update the quantity.
		 */
		var result = 0L;

		if (await FindExisting(stock) is not StockItem existing)
			result = await InsertItem(stock);
		else
			result = await UpdateItem(existing);

		await cache.Remove(Logistics.Stock.MetaData.StockKey, Result);
		await events.Inserted(this, Stock, Result);

		return result;
	}

	private async Task<long> InsertItem(IStock stock)
	{
		return await StockUtils.Locker.LockAsync(async () =>
		{
			/*
			 * Query again if someone overtook us. 
			 */
			if (await FindExisting(stock) is not StockItem existing)
			{
				/*
				 * Still doesn't exist, it's safe to insert it since we are in the locked area.
				 */
				var result = await storage.Open<StockItem>().Update(Dto.AsEntity<StockItem>(State.New)) ?? throw new NullReferenceException("IStockItem expected");

				return result.Id;
			}
			else
			{
				/*
				 * Indeed, there was a record inserted in the meantime.
				 */
				return await UpdateItem(existing);
			}
		});
	}
	/// <summary>
	/// Performs the update on the existing stock item.
	/// </summary>
	/// <param name="item">The stock item to be updated.</param>
	private async Task<long> UpdateItem(StockItem item)
	{
		await storage.Open<StockItem>().Update(item, Dto, async () =>
		{
			await cache.Remove(Logistics.Stock.MetaData.StockKey, item.Id);

			return SetState(await Stock.SelectItem(Dto.CreatePrimaryKey(item.Id)) as StockItem);
		},
		Caller,
		async (e) =>
		{
			var quantity = item.Quantity + Dto.Quantity;

			await Task.CompletedTask;

			return e.Merge(Dto, State.Default, new { Quantity = quantity });
		});

		return item.Id;
	}

	private async Task<StockItem?> FindExisting(IStock stock)
	{
		var dto = Dto.Create<IQueryStockItemsDto>();

		dto.Id = stock.Id;
		dto.Location = Dto.Location;
		dto.Serial = Dto.Serial;

		var items = await Stock.QueryItems(dto);

		if (items.IsEmpty || items[0] is not StockItem existing)
			return null;

		return existing;
	}

	protected override async Task OnCommitted()
	{
		if (!IsLeaf)
			return;

		var dto = Dto.Create<IInsertOptionsDto>();

		dto.Queue = "stock";

		await queue.Insert<StockAggregator, IPrimaryKeyDto<long>>(Dto.CreatePrimaryKey(Result), dto);
	}
}