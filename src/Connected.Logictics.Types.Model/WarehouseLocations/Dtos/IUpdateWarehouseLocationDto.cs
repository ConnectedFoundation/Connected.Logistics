using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.WarehouseLocations.Dtos;

public interface IUpdateWarehouseLocationDto : IPrimaryKeyDto<int>
{
	int? Parent { get; set; }
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}
