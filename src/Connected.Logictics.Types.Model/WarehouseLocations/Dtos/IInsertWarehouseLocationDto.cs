using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.WarehouseLocations.Dtos;

public interface IInsertWarehouseLocationDto : IDto
{
	int? Parent { get; set; }
	int Warehouse { get; set; }
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}
