using Connected.Services;

namespace TomPIT.Logistics.Stock;

public interface IQueryStockItemsDto : IPrimaryKeyDto<long>
{
	int Location { get; set; }
	/// <summary>
	/// The optional serial number.
	/// </summary>
	long? Serial { get; set; }
}