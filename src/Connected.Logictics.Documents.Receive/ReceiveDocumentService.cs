using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Logictics.Documents.Receive.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive;

internal sealed class ReceiveDocumentService(IServiceProvider services)
	: Service(services), IReceiveDocumentService
{
	public async Task<int> Insert(IInsertReceiveDocumentDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Update(IUpdateReceiveDocumentDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}

	public async Task Patch(IPatchDto<int> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<IReceiveDocument?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task<ImmutableList<IReceiveDocument>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}
}