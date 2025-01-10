using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Logictics.Documents.Receive.Items.Dtos;
internal class SelectReceiveItemDto : Dto, ISelectReceiveItemDto
{
	[MinValue(1)]
	public int Head { get; set; }

	[Required, MaxLength(128)]
	public required string Entity { get; set; }

	[Required, MaxLength(128)]
	public required string EntityId { get; set; }
}
