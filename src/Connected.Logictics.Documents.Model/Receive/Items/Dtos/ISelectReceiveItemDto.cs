using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Items.Dtos;

public interface ISelectReceiveItemDto : IEntityDto
{
	int Head { get; set; }
}