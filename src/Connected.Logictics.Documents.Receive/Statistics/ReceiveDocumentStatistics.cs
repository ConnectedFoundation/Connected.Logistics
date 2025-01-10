using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities.Concurrency;

namespace Connected.Logictics.Documents.Receive.Statistics;
internal record ReceiveDocumentStatistics : ConcurrentEntity<int>, IReceiveDocumentStatistics
{
	[PrimaryKey(false)]
	[Ordinal(0)]
	public override int Id { get; init; }

	[Ordinal(1)]
	public int ItemCount { get; init; }

	[Ordinal(2)]
	public int OpenItemCount { get; init; }

	[Ordinal(3)]
	public int PostingDocumentCount { get; init; }
}
