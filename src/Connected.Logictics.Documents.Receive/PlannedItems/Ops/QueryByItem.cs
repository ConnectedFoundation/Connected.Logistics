using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Ops;
internal class QueryByItem(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyDto<long>, ImmutableList<IReceivePlannedItem>>
{
	protected override async Task<ImmutableList<IReceivePlannedItem>> OnInvoke()
	{
		return await storage.Open<ReceivePlannedItem>().AsEntities<IReceivePlannedItem>(f => f.Item == Dto.Id);
	}
}
