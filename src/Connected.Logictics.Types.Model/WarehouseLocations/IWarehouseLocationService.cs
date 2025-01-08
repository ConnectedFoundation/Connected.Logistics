using Connected.Annotations;
using Connected.Logistics.Types.WarehouseLocations.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logistics.Types.WarehouseLocations;

[Service, ServiceUrl(Urls.WarehouseLocations)]
public interface IWarehouseLocationService
{
	Task<ImmutableList<IWarehouseLocation>> Query(IQueryDto? dto);
	/// <summary>
	/// Queries warehouse locations for the specified <see cref="IWarehouse"/>.
	/// </summary>
	/// <param name="dto">The arguments containing the id of the warehouse.</param>
	/// <returns>The list of warehouse locations that belong to the specified warehouse.</returns>
	Task<ImmutableList<IWarehouseLocation>> Query(IQueryWarehouseLocationsDto dto);
	Task<ImmutableList<IWarehouseLocation>> Query(IPrimaryKeyListDto<int> dto);
	Task<ImmutableList<IWarehouseLocation>> QueryChildren(IQueryWarehouseLocationChildrenDto dto);

	Task<IWarehouseLocation?> Select(IPrimaryKeyDto<int> dto);
	Task<IWarehouseLocation?> Select(ISelectWarehouseLocationDto dto);

	Task<int> Insert(IInsertWarehouseLocationDto dto);
	Task Update(IUpdateWarehouseLocationDto dto);
	Task Patch(IPatchDto<int> dto);
	Task Delete(IPrimaryKeyDto<int> dto);
}
