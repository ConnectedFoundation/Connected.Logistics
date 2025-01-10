using Connected.Entities;
using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Items.Ops;
internal class SelectByEntity(IStorageProvider storage, IReceiveItemCache cache)
	: ServiceFunction<ISelectReceiveItemDto, IReceiveItem?>
{
	protected override async Task<IReceiveItem?> OnInvoke()
	{
		return await cache.Get(f => f.Head == Dto.Head
			&& string.Equals(f.Entity, Dto.Entity, StringComparison.OrdinalIgnoreCase)
			&& string.Equals(f.EntityId, Dto.EntityId, StringComparison.OrdinalIgnoreCase), async (f) =>
		{
			return await storage.Open<ReceiveItem>().Where(f => f.Head == Dto.Head
							&& string.Equals(f.Entity, Dto.Entity, StringComparison.OrdinalIgnoreCase)
							&& string.Equals(f.EntityId, Dto.EntityId, StringComparison.OrdinalIgnoreCase)).AsEntity();
		});
	}
}
