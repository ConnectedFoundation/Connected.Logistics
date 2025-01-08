using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive;

[Service, ServiceUrl(Urls.ReceiveDocumentStatistics)]
public interface IReceiveDocumentStatisticsService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateReceiveDocumentStatisticsDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<ImmutableList<IReceiveDocumentStatistics>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<IReceiveDocumentStatistics?> Select(IPrimaryKeyDto<long> dto);
}