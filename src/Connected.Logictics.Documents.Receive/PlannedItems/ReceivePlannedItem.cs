using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Logictics.Documents.Receive.PlannedItems;

[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal sealed record ReceivePlannedItem : Entity<long>, IReceivePlannedItem
{
	private const string IndexName = $"idx_{SchemaAttribute.LogisticsSchema}_{nameof(IReceivePlannedItem)}";

	[Ordinal(-1), PrimaryKey(false)]
	public override long Id { get; init; }

	[Ordinal(0), Index(true, IndexName)]
	public int Head { get; init; }

	[Ordinal(1), Index(true, IndexName)]
	public int Item { get; init; }

	[Ordinal(2)]
	public double Quantity { get; init; }

	[Ordinal(3)]
	public double PostedQuantity { get; init; }
}
