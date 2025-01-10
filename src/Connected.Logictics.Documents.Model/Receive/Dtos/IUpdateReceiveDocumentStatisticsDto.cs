using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IUpdateReceiveDocumentStatisticsDto : IDto
{
	int Id { get; set; }
	int ItemCount { get; set; }
	int OpenItemCount { get; set; }
	int PostingDocumentCount { get; set; }
}