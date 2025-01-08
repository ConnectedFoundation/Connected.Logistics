using Connected.Services;

namespace Connected.Logistics.Types.WarehouseLocations.Dtos;

public interface IQueryWarehouseLocationsDto : IDto
{
	int Warehouse { get; set; }
}
