using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IUpdateReceivePlannedItemDto : IPrimaryKeyDto<long>
{
	public float PostedQuantity { get; set; }
}
