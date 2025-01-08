using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.Warehouses.Dtos;

public interface IInsertWarehouseDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}
