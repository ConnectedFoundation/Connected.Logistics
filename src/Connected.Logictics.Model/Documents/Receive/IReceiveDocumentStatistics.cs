using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceiveDocumentStatistics : IEntity<int>
{
	int ItemCount { get; init; }
	int OpenItemCount { get; init; }
	int PostingDocumentCount { get; init; }
}
