using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;

public interface IReceivePostingDocumentStatistics : IEntity<int>
{
	int OpenItemCount { get; init; }
	int ItemCount { get; init; }
}