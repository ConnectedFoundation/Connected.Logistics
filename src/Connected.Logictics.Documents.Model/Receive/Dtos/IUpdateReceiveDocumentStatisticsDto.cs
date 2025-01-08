using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

public interface IUpdateReceiveDocumentStatisticsDto : IDto
{
	int Id { get; set; }
	int ItemCount { get; init; }
	int OpenItemCount { get; init; }
	int PostingDocumentCount { get; init; }
}