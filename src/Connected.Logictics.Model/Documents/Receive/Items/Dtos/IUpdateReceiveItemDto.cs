using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Items.Dtos;

public interface IUpdateReceiveItemDto : IPrimaryKeyDto<long>
{
	double PostedQuantity { get; set; }
}
