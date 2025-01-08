using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceivePostingItem : IEntity<long>
{
	int Head { get; init; }
	long Serial { get; init; }
	float Quantity { get; init; }
	int Location { get; init; }
}
