using Connected.Services;

namespace Connected.Logistics.Types.Packaging.Dtos;

public interface ISelectPackingDto : IDto
{
	string Ean { get; set; }
}