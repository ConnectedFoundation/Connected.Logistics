using Connected.Annotations;
using Connected.Logistics.Types.Warehouses.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logistics.Types.Warehouses;

[Service, ServiceUrl(Urls.Warehouses)]
public interface IWarehouseService
{
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IWarehouse>> Query(IQueryDto? dto);


	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("lookup")]
	Task<ImmutableList<IWarehouse>> Query(IPrimaryKeyListDto<int> dto);


	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IWarehouse?> Select(IPrimaryKeyDto<int> dto);


	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertWarehouseDto dto);


	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Update(IUpdateWarehouseDto dto);


	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);


	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);
}
