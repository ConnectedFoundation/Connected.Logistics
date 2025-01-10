using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Statistics.Dtos;
internal class UpdateReceiveDocumentStatisticsDto : Dto, IUpdateReceiveDocumentStatisticsDto
{
	[MinValue(1)]
	public int Id { get; set; }

	[MinValue(0)]
	public int ItemCount { get; set; }

	[MinValue(0)]
	public int OpenItemCount { get; set; }

	[MinValue(0)]
	public int PostingDocumentCount { get; set; }
}
