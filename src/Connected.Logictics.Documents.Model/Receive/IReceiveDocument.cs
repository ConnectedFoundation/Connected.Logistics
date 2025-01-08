using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceiveDocument : IEntity<int>
{
	int? Customer { get; init; }
	long Document { get; init; }
	DateTimeOffset? Date { get; init; }
	int? Warehouse { get; init; }
}
