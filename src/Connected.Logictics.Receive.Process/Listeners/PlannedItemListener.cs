using Connected.Annotations;
using Connected.Logictics.Documents.Receive;
using Connected.Logictics.Documents.Receive.Items;
using Connected.Logictics.Documents.Receive.PlannedItems;
using Connected.Logictics.Documents.Receive.Posting;
using Connected.Notifications;
using Connected.Services;
using Microsoft.Extensions.Logging;

namespace Connected.Logictics.Receive.Listeners;

[Middleware<IReceivePlannedItemService>(ServiceEvents.Inserted)]
internal sealed class PlannedItemListener(ILogger<PlannedItemListener> logger, IReceivePostingDocumentService documents,
	IReceiveDocumentService receiveDocuments, IReceivePlannedItemService plannedItems, IReceiveItemService items)
	: EventListener<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		if (await plannedItems.Select(Dto) is not IReceivePlannedItem item)
		{
			logger.LogWarning("The IReceivePlannedItem not found ({dto}).", Dto.Id);
			return;
		}

		if (await items.Select(Dto.CreatePrimaryKey<long>(item.Item)) is not IReceiveItem receiveItem)
		{
			logger.LogWarning("The IReceiveItem not found ({item}).", item.Item);
			return;
		}

		if (await documents.Select(Dto.CreatePrimaryKey(item.Head)) is not IReceivePostingDocument document)
		{
			logger.LogWarning("The IReceivePostingDocument not found ({item}).", item.Head);
			return;
		}

		await UpdateOpenItems(document);
		await UpdatePostedQuantity(receiveItem);
	}

	private async Task UpdateOpenItems(IReceivePostingDocument document)
	{
		var items = await plannedItems.Query(Dto.CreateHead(document.Id));

		await documents.Patch(Dto.CreatePatch(document.Id, new Dictionary<string, object?>
		{
			{nameof(IReceivePostingDocumentStatistics.OpenItemCount), items.Count(f => f.PostedQuantity < f.Quantity) }
		}));
	}

	private async Task UpdatePostedQuantity(IReceiveItem item)
	{
		var items = await plannedItems.Query(Dto.CreateHead((int)item.Id));

		await plannedItems.Patch(Dto.CreatePatch(item.Id, new Dictionary<string, object?>
		{
			{nameof(IReceiveItem.PostedQuantity), items.Sum(f => f.PostedQuantity) }
		}));
	}
}
