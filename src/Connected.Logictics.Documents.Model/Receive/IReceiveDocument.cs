using Connected.Documents;

namespace Connected.Logictics.Documents.Receive;

public interface IReceiveDocument : IDocument<int>
{
	int? Customer { get; init; }
	DateTimeOffset? Received { get; init; }
	int? Warehouse { get; init; }
	DefaultDocumentStatus Status { get; init; }
}
