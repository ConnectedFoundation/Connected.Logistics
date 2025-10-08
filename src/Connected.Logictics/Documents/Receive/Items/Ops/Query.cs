using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Query(IStorageProvider storage)
	: ServiceFunction<IHeadDto<int>, IImmutableList<IReceiveItem>>
{
	protected override async Task<IImmutableList<IReceiveItem>> OnInvoke()
	{
		return await storage.Open<ReceiveItem>().AsEntities<IReceiveItem>(f => f.Head == Dto.Head);
	}
}
