using Connected.Entities;
using Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Ops;
internal class Update(IStorageProvider storage, IReceivePlannedItemService items, IEventService events)
	: ServiceAction<IUpdateReceivePlannedItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceivePlannedItem);

		if (entity is null)
		{
			await storage.Open<ReceivePlannedItem>().Update(Dto.AsEntity<ReceivePlannedItem>(State.New));
			await events.Inserted(this, items, Dto.Id);
		}
		else
		{
			await storage.Open<ReceivePlannedItem>().Update(entity.Merge(Dto, State.Default), Dto, async () =>
			{
				return SetState(await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceivePlannedItem);
			}, Caller);
			await events.Updated(this, items, entity.Id);
		}
	}
}
