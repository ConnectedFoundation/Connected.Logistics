using Connected.Annotations;
using Connected.Logictics.Documents.Receive;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Logistics.Types.SerialNumbers;
using Connected.Notifications;
using Connected.Services;
using Microsoft.Extensions.Logging;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Receive.Listeners;
/// <summary>
/// Represents the event listener to the <see cref="IReceivePostingDocumentService"/> Updated event. 
/// </summary>
/// <remarks>
/// This middleware reacts when the item is inserted and updates the <see cref="IStockItem"/>.
/// </remarks>
/// <remarks>
/// Creates a new instance of the <see cref="PostingItemListener"/>
/// </remarks>
[Middleware<IReceivePostingItemService>(ServiceEvents.Inserted)]
internal sealed class PostingItemListener(ILogger<PostingItemListener> logger, IStockService stock,
	ISerialNumberService serials, IReceivePostingItemService items, IReceivePlannedItemService plannedItems)
	: EventListener<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		/*
		 * Stage 1 is to prepare all data neede to perform operation
		 * 
		 * Load posting item
		 */
		if (await items.Select(Dto) is not IReceivePostingItem item)
		{
			logger.LogWarning("The IReceivePostingItem not found ({Dto.Id}).", Dto.Id);
			return;
		}
		/*
		 * Now load the serial number
		 */
		if (await serials.Select(Dto.CreatePrimaryKey(item.Serial)) is not ISerialNumber serial)
		{
			logger.LogWarning("The ISerialNumber not found ({serial}).", item.Serial);
			return;
		}
		/*
		 * Now load the serial number
		 */
		var plannedItemDto = Dto.Create<ISelectReceivePlannedItemDto>();

		plannedItemDto.Head = item.Head;
		plannedItemDto.Entity = serial.Entity;
		plannedItemDto.EntityId = serial.EntityId;

		if (await plannedItems.Select(plannedItemDto) is not ISerialNumber plannedItem)
		{
			logger.LogWarning("The IReceivePlannedItem not found ({entity}, {entityId}).", serial.Entity, serial.EntityId);
			return;
		}
		/*
		 * The idea here is simple:
		 * update (increase) the stock for the specified item 
		 * and posted quantity and update the statictics for
		 * the immediate parents.
		 */
		var stockDto = Dto.Create<IUpdateStockDto>();

		stockDto.Location = item.Location;
		stockDto.Quantity = item.Quantity;
		stockDto.Serial = item.Serial;

		await stock.Update(stockDto);
		/*
		 * Now update the planned item with posted quantity
		 */
		var updatePlannedDto = Dto.Create<IUpdateReceivePlannedItemDto>();

		updatePlannedDto.Id = plannedItem.Id;
		updatePlannedDto.PostedQuantity = item.Quantity;

		await plannedItems.Update(updatePlannedDto);
	}
}
