using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock;

[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal sealed record Stock : ConsistentEntity<long>, IStock
{
	private const string IndexName = $"ix_logistics_stock_{nameof(Entity)}_{nameof(EntityId)}";

	[Ordinal(0), Length(128), Index(true, IndexName)]
	public required string Entity { get; init; }

	[Ordinal(1), Length(128), Index(true, IndexName)]
	public string EntityId { get; init; } = default!;

	[Ordinal(2)]
	public float Quantity { get; init; }

	[Ordinal(3)]
	public float? Min { get; init; }

	[Ordinal(4)]
	public float? Max { get; init; }
}
