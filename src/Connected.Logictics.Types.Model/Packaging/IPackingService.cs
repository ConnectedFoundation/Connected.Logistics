using Connected.Annotations;
using Connected.Logistics.Types.Packaging.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logistics.Types.Packaging;

[Service, ServiceUrl(Urls.Packing)]
public interface IPackingService
{
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IPacking>> Query(IQueryDto? dto);


	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IPacking>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IPacking?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IPacking?> Select(ISelectPackingDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertPackingDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Update(IUpdatePackingDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Delete | ServiceOperationVerbs.Post)]
	Task Delete(IPrimaryKeyDto<int> dto);
}
