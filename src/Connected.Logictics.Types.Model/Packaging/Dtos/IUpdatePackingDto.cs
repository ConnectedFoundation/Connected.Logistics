using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.Packaging.Dtos;

public interface IUpdatePackingDto : IPrimaryKeyDto<int>
{
	string Ean { get; set; }
	float? Quantity { get; set; }
	float? NetWeight { get; set; }
	float? GrossWeight { get; set; }
	int? Width { get; set; }
	int? Height { get; set; }
	int? Depth { get; set; }
	int? ItemCount { get; set; }
	Status Status { get; set; }
}
