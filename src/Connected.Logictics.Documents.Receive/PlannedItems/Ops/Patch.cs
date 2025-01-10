using Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Ops;
internal class Patch(IReceivePlannedItemService items)
	: ServiceAction<IPatchDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = await items.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as ReceivePlannedItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await items.Update(Dto.Patch<IUpdateReceivePlannedItemDto, ReceivePlannedItem>(entity));
	}
}
