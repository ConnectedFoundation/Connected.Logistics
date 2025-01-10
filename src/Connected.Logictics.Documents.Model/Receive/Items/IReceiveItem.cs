using Connected.Entities;

namespace Connected.Logictics.Documents.Receive.Items;

public interface IReceiveItem : IEntityContainer<long>
{
	int Head { get; init; }
	double Quantity { get; init; }
	double PostedQuantity { get; init; }
}
