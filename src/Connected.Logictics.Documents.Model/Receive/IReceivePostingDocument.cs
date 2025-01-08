using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceivePostingDocument : IEntity<int>
{
	int Head { get; init; }
	long Document { get; init; }
}
