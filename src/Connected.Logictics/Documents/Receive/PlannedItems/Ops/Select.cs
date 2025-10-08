using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Ops;
internal class Select(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyDto<long>, IReceivePlannedItem?>
{
	protected override async Task<IReceivePlannedItem?> OnInvoke()
	{
		return await storage.Open<ReceivePlannedItem>().AsEntity(f => f.Id == Dto.Id);
	}
}
