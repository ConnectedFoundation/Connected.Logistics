using Connected.Entities;

namespace Connected.Logistics.Types.WarehouseLocations;
/// <summary>
/// Represents a physical or logical location inside a <see cref="IWarehouse"/>.
/// </summary>
/// <remarks>
/// Each <see cref="IWarehouse"/> contains zero or more <see cref="IWarehouseLocation">locations</see>. 
/// Location can be a container, which means it contains child locations, or leaf, which doesn't contain
/// child locations. Items can be put only in leaf locations, whereas containers acts only as aggregators
/// which means they provide calculated values for items contained in the child locations.
/// </remarks>
public interface IWarehouseLocation : IEntity<int>
{
	int? Parent { get; init; }
	int Warehouse { get; init; }
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
	/// <summary>
	/// The number of direct child items that belong to this
	/// location. If this value is 0 it means the location
	/// is leaf. If not, it's a container.
	/// </summary>
	int ItemCount { get; init; }
}
