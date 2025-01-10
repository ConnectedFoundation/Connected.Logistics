using Connected.Entities;

namespace Connected.Logictics.Documents.Receive.Posting;

public interface IReceivePostingDocumentStatistics : IEntity<int>
{
	int OpenItemCount { get; init; }
	int ItemCount { get; init; }
}