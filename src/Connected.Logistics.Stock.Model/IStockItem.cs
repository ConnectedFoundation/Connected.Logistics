using Connected.Entities;

namespace TomPIT.Logistics.Stock;
/// <summary>
/// Represents a single stock item.
/// </summary>
/// <remarks>
/// Goods are typically stored in a warehouse. Warehouse is
/// organized into locations or storage bins and each location contains
/// zero or more goods.
/// </remarks>
public interface IStockItem : IEntity<long>
{
	/// <summary>
	/// The <see cref="IStock"/> to which the item belong.
	/// </summary>
	/// <remarks>
	/// Stock contains information about the type of the entity whereas
	/// the stock item contains information about actual storage.
	/// </remarks>
	long Stock { get; init; }
	/// <summary>
	/// The location where the goods are stored.
	/// </summary>
	int Location { get; init; }
	/// <summary>
	/// The serial number of the goods.
	/// </summary>
	/// <remarks>
	/// Each item has a serial number which uniquely identifies
	/// the items even from the same type but from
	/// different documents.
	/// </remarks>
	long Serial { get; init; }
	/// <summary>
	/// The quantity left in this location. Once the quantity reaches zero
	/// the item gets deleted from the location.
	/// </summary>
	float Quantity { get; init; }
}
