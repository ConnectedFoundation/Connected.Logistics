using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IInsertReceiveDocumentDto : IDto
{
	int? Warehouse { get; set; }
	int? Customer { get; set; }
	long Document { get; set; }
	string? Code { get; set; }
}
