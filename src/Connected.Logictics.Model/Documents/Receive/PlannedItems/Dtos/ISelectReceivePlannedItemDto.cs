using Connected.Services;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Dtos;

public interface ISelectReceivePlannedItemDto : IEntityDto
{
	int Head { get; set; }
}
