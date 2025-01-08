using Connected.Entities;

namespace Connected.Logictics.Documents.Receive;
/// <summary>
/// Represents connected (many-to-many) entity between <see cref="IReceivePostingDocument"/>
/// and <see cref="IReceiveItem"/>.
/// </summary>
/// <remarks>
/// Master receive document contains one or more <see cref="IReceiveItem"/> items. Receive document
/// is then divided into one or more <see cref="IReceivePostingDocument"/> documents which contain
/// two lists of items:
/// <list type="bullet">
/// <item><see cref="IReceivePlannedItem"/></item>
/// <item><see cref="IReceivePostingItem"/></item>
/// </list>
/// This entity represents planned items which represents the plan of how what kind of item and how
/// much should be posted to each <see cref="IReceivePostingDocument"/>. This acts only as a guide to the user
/// not the actual items and quantities that arrived into warehouse.
/// </remarks>
public interface IReceivePlannedItem : IEntity<long>
{
	/// <summary>
	/// The id of the <see cref="IReceivePostingDocument"/> to which
	/// this planned entity belongs.
	/// </summary>
	int Head { get; init; }
	/// <summary>
	/// The id of the <see cref="IReceiveItem"/> item to which
	/// this planned entity belongs.
	/// </summary>
	int Item { get; init; }
	/// <summary>
	/// The planned entity which should be posted into this
	/// item.
	/// </summary>
	float Quantity { get; init; }
	/// <summary>
	/// The actual posted quantity for this item.
	/// </summary>
	float PostedQuantity { get; init; }
}
