using Connected.Services;

namespace Connected.Logistics.Types.WarehouseLocations.Dtos;

public interface ISelectWarehouseLocationDto : IDto
{
	string Code { get; set; }
}
