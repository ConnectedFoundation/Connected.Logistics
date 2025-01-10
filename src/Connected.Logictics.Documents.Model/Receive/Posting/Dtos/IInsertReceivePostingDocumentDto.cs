using Connected.Documents.Dtos;

namespace Connected.Logictics.Documents.Receive.Posting.Dtos;

public interface IInsertReceivePostingDocumentDto : IInsertDocumentDto
{
	int Head { get; set; }
}
