using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Items.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Items;

[Service, ServiceUrl(Urls.ReceiveItems)]
public interface IReceiveItemService
{
	/// <summary>
	/// Inserts a new <see cref="IReceiveItem"/> into the <see cref="IReceiveDocument"/> document.
	/// </summary>
	/// <param name="args">The arguments containing the properties of the new item.</param>
	/// <returns>The id of the newly inserted <see cref="IReceiveItem"/> item.</returns>
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertReceiveItemDto dto);
	/// <summary>
	/// Updates <see cref="IReceiveItem"/>.
	/// </summary>
	/// <param name="args">The arguments containing the properties to be updated.</param>
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateReceiveItemDto dto);
	/// <summary>
	/// Permanently deleted the <see cref="IReceiveItem"/>.
	/// </summary>
	/// <param name="args">The arguments containing the id of the item to be deleted.</param>
	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);
	/// <summary>
	/// Queries the <see cref="IReceiveItem"/> items for the specified <see cref="IReceiveDocument"/>.
	/// </summary>
	/// <param name="args">The arguments containing the id of the document for which the items to be
	/// queried.</param>
	/// <returns>The list of items that belong to the specified document.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IImmutableList<IReceiveItem>> Query(IHeadDto<int> dto);
	/// <summary>
	/// Selects the <see cref="IReceiveItem"/> item for the specified id.
	/// </summary>
	/// <param name="args">The arguments containing the id of the item.</param>
	/// <returns>The <see cref="IReceiveItem"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IReceiveItem?> Select(IPrimaryKeyDto<long> dto);
	/// <summary>
	/// Select the <see cref="IReceiveItem"/> for the specified entity and entity id from the 
	/// specified document.
	/// </summary>
	/// <param name="args">The arguments containing criteria values.</param>
	/// <returns>A first <see cref="IReceiveItem"/> that matches the criteria, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("select-by-entity")]
	Task<IReceiveItem?> Select(ISelectReceiveItemDto dto);
}