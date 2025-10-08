using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Statistics.Ops;
internal class Lookup(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IReceiveDocumentStatistics>>
{
	protected override async Task<IImmutableList<IReceiveDocumentStatistics>> OnInvoke()
	{
		return await storage.Open<ReceiveDocumentStatistics>().AsEntities<IReceiveDocumentStatistics>(f => Dto.Items.Any(g => g == f.Id));
	}
}