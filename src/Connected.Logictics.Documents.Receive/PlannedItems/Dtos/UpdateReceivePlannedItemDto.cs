using Connected.Annotations;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
internal sealed class UpdateReceivePlannedItemDto : Dto, IUpdateReceivePlannedItemDto
{
	public double PostedQuantity { get; set; }

	[MinValue(1)]
	public long Id { get; set; }
}
