using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Documents;

namespace Connected.Logictics.Documents.Receive;

[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal record ReceiveDocument : Document<int>, IReceiveDocument
{
	[Ordinal(0)]
	public int? Customer { get; init; }

	[Ordinal(1)]
	public long Document { get; init; }

	[Ordinal(2), Date(DateKind.SmallDateTime)]
	public DateTimeOffset? Received { get; init; }

	[Ordinal(3)]
	public int? Warehouse { get; init; }
}
