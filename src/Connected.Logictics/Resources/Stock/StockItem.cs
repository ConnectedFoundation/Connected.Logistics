using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock;
/// <inheritdoc cref="IStockItem"/>
[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal sealed record StockItem : ConsistentEntity<long>, IStockItem
{
	/// <inheritdoc cref="IStockItem.Stock"/>
	[Ordinal(0)]
	public long Stock { get; init; }
	/// <inheritdoc cref="IStockItem.Location"/>
	[Ordinal(1)]
	public int Location { get; init; }
	/// <inheritdoc cref="IStockItem.Serial"/>
	[Ordinal(2)]
	public long Serial { get; init; }
	/// <inheritdoc cref="IStockItem.Quantity"/>
	[Ordinal(3)]
	public float Quantity { get; init; }
}
