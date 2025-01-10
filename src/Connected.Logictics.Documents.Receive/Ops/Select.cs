using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Select(IStorageProvider storage, IReceiveDocumentCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IReceiveDocument?>
{
	protected override async Task<IReceiveDocument?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<ReceiveDocument>().Where(f => f.Id == Dto.Id).AsEntity();
		});
	}
}
