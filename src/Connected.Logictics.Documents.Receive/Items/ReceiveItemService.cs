using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Logictics.Documents.Receive.Items.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Items;

internal class ReceiveItemService(IServiceProvider services)
	: Service(services), IReceiveItemService
{
	public async Task<long> Insert(IInsertReceiveItemDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Update(IUpdateReceiveItemDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}
	public async Task<ImmutableList<IReceiveItem>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IReceiveItem?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}
	public async Task<IReceiveItem?> Select(ISelectReceiveItemDto dto)
	{
		return await Invoke(GetOperation<SelectByEntity>(), dto);
	}
}