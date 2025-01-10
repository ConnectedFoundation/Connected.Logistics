using Connected.Collections.Queues;
using Connected.Logistics.Types.WarehouseLocations;
using Connected.Services;
using Microsoft.Extensions.Logging;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock.Aggregations;

internal sealed class StockAggregator(ILogger<StockAggregator> logger, IWarehouseLocationService locations, IStockService stock)
	: QueueClient<IPrimaryKeyDto<long>>
{
	private IStockService Stock { get; } = stock;

	protected override async Task OnInvoke()
	{
		if (Dto is null)
			return;

		if (await Stock.SelectItem(Dto) is not IStockItem stock)
		{
			logger.LogWarning("IStockItem not found ({id})", Dto.Id);
			return;
		}

		await Calculate(stock, stock.Location);
	}

	private async Task Calculate(IStockItem stock, int locationId)
	{
		if (await locations.Select(Dto.CreatePrimaryKey(locationId)) is not IWarehouseLocation location)
		{
			logger.LogWarning("IWarehouseLocation not found ({locationId})", locationId);
			return;
		}

		if (location.Parent is null)
			return;

		var parent = (int)location.Parent;
		var queryDto = Dto.Create<IQueryStockItemsDto>();

		queryDto.Id = stock.Id;
		queryDto.Location = parent;
		queryDto.Serial = stock.Serial;

		var sum = (await Stock.QueryItems(queryDto)).Sum(f => f.Quantity);
		var updateDto = Dto.Create<IUpdateStockDto>();

		updateDto.Location = parent;
		updateDto.Quantity = sum;
		updateDto.Serial = stock.Serial;

		await Stock.Update(updateDto);
		await Calculate(stock, parent);
	}
}
