using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface ISelectReceivePlannedItemDto : IEntityDto
{
	int Head { get; set; }
}
