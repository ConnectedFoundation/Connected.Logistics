using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Logictics.Documents.Receive.Items;

[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal record ReceiveItem : EntityContainer<long>, IReceiveItem
{
	[Ordinal(0), Index(false)]
	public int Head { get; init; }

	[Ordinal(1)]
	public double Quantity { get; init; }

	[Ordinal(2)]
	public double PostedQuantity { get; init; }
}
