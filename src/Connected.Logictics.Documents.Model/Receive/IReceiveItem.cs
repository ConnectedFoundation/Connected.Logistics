using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceiveItem : IEntityContainer<long>
{
	int Head { get; init; }
	float Quantity { get; init; }
	float PostedQuantity { get; init; }
}
