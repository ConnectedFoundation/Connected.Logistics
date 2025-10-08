using Connected.Entities;
using Connected.Logictics.Documents.Receive.Items;
using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Ops;
internal class SelectByEntity(IStorageProvider storage, IReceiveItemService items)
	: ServiceFunction<ISelectReceivePlannedItemDto, IReceivePlannedItem?>
{
	protected override async Task<IReceivePlannedItem?> OnInvoke()
	{
		var entity = await items.Select(Dto.AsDto<ISelectReceiveItemDto>());

		if (entity is null)
			return null;

		return await storage.Open<ReceivePlannedItem>().AsEntity(f => f.Item == entity.Id);
	}
}
