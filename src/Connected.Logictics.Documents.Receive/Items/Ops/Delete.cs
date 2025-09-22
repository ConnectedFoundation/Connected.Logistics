using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Delete(IStorageProvider storage, IReceiveItemService items, IEventService events, IReceiveItemCache cache)
	: ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceiveItem) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ReceiveItem>().Update(Dto.AsEntity<ReceiveItem>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, items, Dto.Id);
	}
}
