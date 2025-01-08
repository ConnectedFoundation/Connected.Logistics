using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IUpdateReceiveItemDto : IPrimaryKeyDto<long>
{
	float PostedQuantity { get; set; }
}
