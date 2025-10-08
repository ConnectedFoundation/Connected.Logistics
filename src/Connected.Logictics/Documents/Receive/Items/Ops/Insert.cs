using Connected.Entities;
using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Insert(IStorageProvider storage, IReceiveItemService items, IEventService events)
	: ServiceFunction<IInsertReceiveItemDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = await storage.Open<ReceiveItem>().Update(Dto.AsEntity<ReceiveItem>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, items, entity.Id);

		return entity.Id;
	}
}
