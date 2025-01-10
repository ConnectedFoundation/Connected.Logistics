using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class Select(IStorageProvider storage, IReceiveItemCache cache)
	: ServiceFunction<IPrimaryKeyDto<long>, IReceiveItem?>
{
	protected override async Task<IReceiveItem?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<ReceiveItem>().Where(f => f.Id == Dto.Id).AsEntity();
		});
	}
}
