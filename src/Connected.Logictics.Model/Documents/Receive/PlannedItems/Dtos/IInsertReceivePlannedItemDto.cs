using Connected.Services;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Dtos;

public interface IInsertReceivePlannedItemDto : IEntityDto
{
	int Head { get; set; }
	double Quantity { get; set; }
}
