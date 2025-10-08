using Connected.Annotations;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Items.Dtos;
internal class UpdateReceiveItemDto : Dto, IUpdateReceiveItemDto
{
	[MinValue(1)]
	public long Id { get; set; }

	public double PostedQuantity { get; set; }
}
