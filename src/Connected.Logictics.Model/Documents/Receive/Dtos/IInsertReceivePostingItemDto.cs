using Connected.Logictics.Documents.Receive.Posting;
using Connected.Logictics.Documents.Receive.Posting.Items.Dto;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

/// <summary>
/// The arguments used when inserting a new <see cref="IReceivePostingItem"/> item
/// via <see cref="IReceiveDocumentService"/> service.
/// </summary>
public interface IInsertReceivePostingItemDto : IDto
{
	/// <summary>
	/// The id of the <see cref="IReceivePostingDocument"/> document. 
	/// Must exists in the storage.
	/// </summary>
	int Head { get; set; }
	int Location { get; set; }
	double Quantity { get; set; }
	long? Serial { get; set; }
}
