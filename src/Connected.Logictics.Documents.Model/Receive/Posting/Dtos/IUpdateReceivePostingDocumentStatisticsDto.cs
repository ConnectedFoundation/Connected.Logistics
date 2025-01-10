using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Posting.Dtos;

public interface IUpdateReceivePostingDocumentStatisticsDto : IDto
{
	int Id { get; set; }
	int ItemCount { get; set; }
	int OpenItemCount { get; set; }
}
