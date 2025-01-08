using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IInsertReceivePostingDocumentDto : IDto
{
	int Head { get; set; }
	long Document { get; set; }
	string? Code { get; set; }
}
