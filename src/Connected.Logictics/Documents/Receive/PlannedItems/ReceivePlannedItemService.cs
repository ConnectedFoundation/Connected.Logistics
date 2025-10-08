using Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
using Connected.Logictics.Documents.Receive.PlannedItems.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.PlannedItems;

internal sealed class ReceivePlannedItemService(IServiceProvider services) : Service(services), IReceivePlannedItemService
{
	public async Task Patch(IPatchDto<long> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task Update(IUpdateReceivePlannedItemDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}

	public Task<IReceivePlannedItem?> Select(IPrimaryKeyDto<long> dto)
	{
		return Invoke(GetOperation<Select>(), dto);
	}

	public Task<IReceivePlannedItem?> Select(ISelectReceivePlannedItemDto dto)
	{
		return Invoke(GetOperation<SelectByEntity>(), dto);
	}

	public async Task<IImmutableList<IReceivePlannedItem>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}
	public async Task<IImmutableList<IReceivePlannedItem>> Query(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<QueryByItem>(), dto);
	}
}