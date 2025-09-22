using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive;

[Service, ServiceUrl(Urls.ReceiveDocumentStatistics)]
public interface IReceiveDocumentStatisticsService
{
	Task Update(IUpdateReceiveDocumentStatisticsDto dto);
	Task Delete(IPrimaryKeyDto<int> dto);
	Task<IImmutableList<IReceiveDocumentStatistics>> Lookup(IPrimaryKeyListDto<int> dto);
	Task<IReceiveDocumentStatistics?> Select(IPrimaryKeyDto<int> dto);
}