using Connected.Entities;
using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Update(IStorageProvider storage, IReceiveItemService items, IEventService events, IReceiveItemCache cache)
	: ServiceAction<IUpdateReceiveItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceiveItem) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ReceiveItem>().Update(entity.Merge(Dto, State.Default), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return SetState(await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceiveItem);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, items, entity.Id);
	}
}
