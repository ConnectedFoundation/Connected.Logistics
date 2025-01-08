using Connected.Annotations;
using Connected.Logictics.Documents.Receive;
using Connected.Notifications;
using Connected.Services;
using Microsoft.Extensions.Logging;

namespace Connected.Logictics.Receive.Listeners;

[Middleware<IReceiveItemService>(ServiceEvents.Updated)]
internal sealed class ReceiveItemListener(ILogger<ReceiveItemListener> logger, IReceiveDocumentService documents,
	IReceiveItemService items)
	: EventListener<IPrimaryKeyDto<long>>
{
	private IReceiveItemService Items { get; } = items;

	protected override async Task OnInvoke()
	{
		if (await Items.Select(Dto) is not IReceiveItem item)
		{
			logger.LogWarning("The IReceiveItem not found ({id}).", Dto.Id);
			return;
		}

		var items = await Items.Query(Dto.CreateHead(item.Head));

		await documents.Patch(Dto.CreatePatch(item.Head, new Dictionary<string, object?>
			{
				{nameof(IReceiveDocumentStatistics.OpenItemCount), items.Count(f=>f.PostedQuantity < f.Quantity)}
			}));
	}
}
