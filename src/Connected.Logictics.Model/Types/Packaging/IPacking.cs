using Connected.Entities;

namespace Connected.Logistics.Types.Packaging;

public interface IPacking : IEntity<int>
{
	string Ean { get; init; }
	string Entity { get; init; }
	string EntityId { get; init; }
	float? Quantity { get; init; }
	float? NetWeight { get; init; }
	float? GrossWeight { get; init; }
	int? Width { get; init; }
	int? Height { get; init; }
	int? Depth { get; init; }
	int? ItemCount { get; init; }
	Status Status { get; init; }
}
