using Connected.Services;

namespace TomPIT.Logistics.Stock;

public interface IUpdateStockDto : IDto
{
	/// <summary>
	/// The serial number of the item.
	/// </summary>
	long Serial { get; set; }
	/// <summary>
	/// The warehouse location where the items are stored.
	/// </summary>
	int Location { get; set; }
	/// <summary>
	/// The changed quantity. Can be a positive or negative
	/// value.
	/// </summary>
	float Quantity { get; set; }
}
