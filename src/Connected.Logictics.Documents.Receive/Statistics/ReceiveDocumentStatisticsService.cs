using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Logictics.Documents.Receive.Statistics.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Statistics;

internal sealed class ReceiveDocumentStatisticsService(IServiceProvider services)
	: Service(services), IReceiveDocumentStatisticsService
{
	public async Task Update(IUpdateReceiveDocumentStatisticsDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}

	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<IImmutableList<IReceiveDocumentStatistics>> Lookup(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IReceiveDocumentStatistics?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}
}