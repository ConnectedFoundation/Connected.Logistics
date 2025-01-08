using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IUpdateReceiveDocumentDto : IDto
{
	int? Warehouse { get; set; }

	int? Customer { get; set; }

	DateTimeOffset? Date { get; set; }
}
