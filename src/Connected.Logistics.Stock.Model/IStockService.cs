using Connected.Annotations;
using Connected.Services;
using System.Collections.Immutable;

namespace TomPIT.Logistics.Stock;
/// <summary>
/// Represents the service which manipulates with stock items.
/// </summary>
[Service, ServiceUrl(Urls.Stock)]
public interface IStockService
{
	/// <summary>
	/// Updates the stock items at the specified location.
	/// </summary>
	/// <param name="dto"></param>
	Task Update(IUpdateStockDto dto);

	Task<IStock?> Select(IPrimaryKeyDto<long> dto);
	Task<IStock?> Select(IEntityDto dto);
	/// <summary>
	/// Queries all stock items for the specified stock.
	/// </summary>
	/// <param name="dto">The arguments containing the id of the stock</param>
	/// <returns>The list of stock items that belong to the specified stock id.</returns>
	Task<ImmutableList<IStockItem>> QueryItems(IPrimaryKeyDto<long> dto);
	/// <summary>
	/// Queries stock items for the specified stock that are present in the specified
	/// warehouse location.
	/// </summary>
	/// <param name="dto">The arguments containing the crieria used by query.</param>
	/// <returns>The list of stock items that are present in the specified warehouse location and
	/// belong to the specified stock id.</returns>
	Task<ImmutableList<IStockItem>> QueryItems(IQueryStockItemsDto dto);

	Task<IStockItem?> SelectItem(IPrimaryKeyDto<long> dto);
}
