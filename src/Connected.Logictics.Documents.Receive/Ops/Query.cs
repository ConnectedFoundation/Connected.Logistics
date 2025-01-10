using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Query(IStorageProvider storage)
	: ServiceFunction<IQueryDto, ImmutableList<IReceiveDocument>>
{
	protected override async Task<ImmutableList<IReceiveDocument>> OnInvoke()
	{
		return await storage.Open<ReceiveDocument>().WithDto(Dto).AsEntities<IReceiveDocument>();
	}
}
