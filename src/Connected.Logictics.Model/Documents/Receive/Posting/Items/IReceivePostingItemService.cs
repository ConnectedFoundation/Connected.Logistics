using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Logictics.Documents.Receive.Posting;
using Connected.Logictics.Documents.Receive.Posting.Items.Dto;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Posting.Items;

[Service, ServiceUrl(Urls.ReceivePostingItems)]
public interface IReceivePostingItemService
{
	/// <summary>
	/// Inserts a new <see cref="IReceivePostingItem"/> into the <see cref="IReceivePostingDocument"/> document.
	/// </summary>
	/// <param name="args">The arguments containing the properties of the new item.</param>
	/// <returns>The id of the newly inserted <see cref="IReceivePostingItem"/> item.</returns>
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertReceivePostingItemDto dto);
	/// <summary>
	/// Queries the <see cref="IReceivePostingItem"/> items for the specified <see cref="IReceivePostingDocument"/>.
	/// </summary>
	/// <param name="args">The arguments containing the id of the document for which the items to be
	/// queried.</param>
	/// <returns>The list of items that belong to the specified document.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IReceivePostingItem>> Query(IHeadDto<int> dto);
	/// <summary>
	/// Selects the <see cref="IReceivePostingItem"/> item for the specified id.
	/// </summary>
	/// <param name="args">The arguments containing the id of the item.</param>
	/// <returns>The <see cref="IReceivePostingItem"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IReceivePostingItem?> Select(IPrimaryKeyDto<long> dto);
}