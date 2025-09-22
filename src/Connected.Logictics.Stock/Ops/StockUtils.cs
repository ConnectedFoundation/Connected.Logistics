using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using Connected.Threading;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock.Ops;

internal static class StockUtils
{
	public const string StockQueue = "Stock";

	static StockUtils()
	{
		Locker = new();
	}

	public static AsyncLockerSlim Locker { get; }
	/// <summary>
	/// This method ensures that a stock (parent) record exists.
	/// </summary>
	/// <remarks>
	/// The stock record is not created explicitly since this would introduce unnecessary complexity. It is
	/// instead created on the fly when the first request is made. The tricky part is it must be thread safe
	/// so we need an async locker since lock statement does not support async calls.
	/// </remarks>
	public static async Task<IStock> Ensure(IStorageProvider storage, IStockService stock, IEntityDto dto)
	{
		/*
		 * First check for existence so we don't need to perform a lock if the record is found.
		 */
		if (await stock.Select(dto) is IStock existing)
			return existing;
		/*
		 * Doesn't exist.
		 * Perform an async lock to ensure no one else is trying to insert the item.
		 */
		return await Locker.LockAsync(async () =>
		{
			/*
			 * Read again if two or more threads were competing for the insert. The thing is this
			 * is happening quite frequently even in semi loaded warehouse systems.
			 */
			if (await stock.Select(dto) is IStock existing2)
				return existing2;
			/*
			 * Still nothing. We are safe to insert a new stock descriptor. Note that in scalable environments
			 * there is still a possibillity that two requests would made it here but from different processes.
			 * Thus we should have a unique constraint on the entity ensuring only one request will win, all the others
			 * lose. This also means the provider owning the entity must support unique constraints.
			 */
			var entity = await storage.Open<Stock>().Update(dto.AsEntity<Stock>(State.Add)) ?? throw new NullReferenceException("Stock entity not found.");

			return await stock.Select(Dto.Factory.CreatePrimaryKey(entity.Id)) ?? throw new NullReferenceException(nameof(IStock));
		});
	}
}