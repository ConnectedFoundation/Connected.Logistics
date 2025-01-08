using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface ISelectReceiveItemDto : IEntityDto
{
	int Head { get; set; }
}