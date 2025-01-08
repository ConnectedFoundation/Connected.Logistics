using Connected.Services;

namespace Connected.Logistics.Types.WarehouseLocations.Dtos;

public interface IQueryWarehouseLocationChildrenDto : IDto
{
	int Warehouse { get; set; }
	int? Parent { get; set; }
}