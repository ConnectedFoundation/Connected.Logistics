using Connected.Annotations;
using Connected.Logictics.Documents.Receive;
using Connected.Logictics.Documents.Receive.Items;
using Connected.Notifications;
using Connected.Services;
using Microsoft.Extensions.Logging;

namespace Connected.Logictics.Receive.Listeners;

[Middleware<IReceiveItemService>(ServiceEvents.Updated)]
internal sealed class ReceiveItemListener(ILogger<ReceiveItemListener> logger, IReceiveDocumentService documents, IReceiveItemService items)
	: EventListener<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		if (await items.Select(Dto) is not IReceiveItem item)
		{
			logger.LogWarning("The IReceiveItem not found ({id}).", Dto.Id);
			return;
		}

		var entities = await items.Query(Dto.CreateHead(item.Head));
		var openCount = entities.Count(f => f.PostedQuantity < f.Quantity);
		var props = new Dictionary<string, object?> { { nameof(IReceiveDocumentStatistics.OpenItemCount), openCount } };

		await documents.Patch(Dto.CreatePatch(item.Head, props));
	}
}
