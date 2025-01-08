using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Dtos;

/// <summary>
/// The arguments used when inserting a new <see cref="IReceiveItem"/> item
/// via <see cref="IReceiveDocumentService"/> service.
/// </summary>
public interface IInsertReceiveItemDto : IEntityDto
{
	/// <summary>
	/// The id of the <see cref="IReceiveDocument"/> document. 
	/// Must exists in the storage.
	/// </summary>
	int Head { get; set; }
	float Quantity { get; set; }
}
