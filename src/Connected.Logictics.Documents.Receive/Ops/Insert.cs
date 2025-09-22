using Connected.Entities;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Insert(IStorageProvider storage, IReceiveDocumentService documents, IEventService events)
	: ServiceFunction<IInsertReceiveDocumentDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<ReceiveDocument>().Update(Dto.AsEntity<ReceiveDocument>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, documents, entity.Id);

		return entity.Id;
	}
}
