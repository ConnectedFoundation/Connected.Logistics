using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Statistics.Ops;
internal class Lookup(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyListDto<int>, ImmutableList<IReceiveDocumentStatistics>>
{
	protected override async Task<ImmutableList<IReceiveDocumentStatistics>> OnInvoke()
	{
		return await storage.Open<ReceiveDocumentStatistics>().AsEntities<IReceiveDocumentStatistics>(f => Dto.Items.Any(g => g == f.Id));
	}
}