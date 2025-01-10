using Connected.Documents;
using Connected.Documents.Dtos;

namespace Connected.Logictics.Documents.Receive.Dtos;
internal class InsertReceiveDocumentDto : InsertDocumentDto, IInsertReceiveDocumentDto
{
	public int? Warehouse { get; set; }
	public int? Customer { get; set; }
	public DateTimeOffset? Received { get; set; }
	public DefaultDocumentStatus Status { get; set; }
}
