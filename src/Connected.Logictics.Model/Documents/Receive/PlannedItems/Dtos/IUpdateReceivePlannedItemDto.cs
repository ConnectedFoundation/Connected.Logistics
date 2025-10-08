using Connected.Services;

namespace Connected.Logictics.Documents.Receive.PlannedItems.Dtos;

public interface IUpdateReceivePlannedItemDto : IPrimaryKeyDto<long>
{
	double PostedQuantity { get; set; }
}
