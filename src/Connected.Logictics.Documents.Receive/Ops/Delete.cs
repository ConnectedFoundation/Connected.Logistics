using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Delete(IStorageProvider storage, IReceiveDocumentService documents, IEventService events)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await documents.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocument) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ReceiveDocument>().Update(Dto.AsEntity<ReceiveDocument>(State.Deleted));
		await events.Deleted(this, documents, Dto.Id);
	}
}
