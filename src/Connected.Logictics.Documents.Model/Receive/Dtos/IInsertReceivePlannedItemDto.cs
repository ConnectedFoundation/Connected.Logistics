using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IInsertReceivePlannedItemDto : IEntityDto
{
	int Head { get; set; }
	float Quantity { get; set; }
}
