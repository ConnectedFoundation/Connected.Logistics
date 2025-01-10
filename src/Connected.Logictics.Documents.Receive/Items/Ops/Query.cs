using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Query(IStorageProvider storage)
	: ServiceFunction<IHeadDto<int>, ImmutableList<IReceiveItem>>
{
	protected override async Task<ImmutableList<IReceiveItem>> OnInvoke()
	{
		return await storage.Open<ReceiveItem>().AsEntities<IReceiveItem>(f => f.Head == Dto.Head);
	}
}
