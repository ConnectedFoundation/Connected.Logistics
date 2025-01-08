using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.Warehouses.Dtos;

public interface IUpdateWarehouseDto : IDto
{
	int Id { get; set; }
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}
