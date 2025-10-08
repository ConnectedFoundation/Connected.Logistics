using Connected.Documents.Dtos;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IInsertReceiveDocumentDto : IInsertDocumentDto
{
	int? Warehouse { get; set; }
	int? Customer { get; set; }
	DateTimeOffset? Received { get; set; }
}
