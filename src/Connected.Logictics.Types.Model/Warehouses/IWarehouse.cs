using Connected.Entities;

namespace Connected.Logistics.Types.Warehouses;

public interface IWarehouse : IEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}
