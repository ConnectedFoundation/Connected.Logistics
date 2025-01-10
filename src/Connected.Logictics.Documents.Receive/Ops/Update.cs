using Connected.Entities;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Update(IStorageProvider storage, IReceiveDocumentService documents, IEventService events, IReceiveDocumentCache cache)
	: ServiceAction<IUpdateReceiveDocumentDto>
{
	protected override async Task OnInvoke()
	{
		var existing = SetState(await documents.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocument) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ReceiveDocument>().Update(existing.Merge(Dto, State.Default), Dto, async () =>
		{
			await cache.Remove(Dto.Id);
			return SetState(await documents.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocument);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, documents, Dto.Id);
	}
}
