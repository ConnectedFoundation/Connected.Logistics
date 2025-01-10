using Connected.Annotations;
using Connected.Logictics.Documents.Receive.PlannedItems.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.PlannedItems;

[Service, ServiceUrl(Urls.ReceivePlannedItems)]
public interface IReceivePlannedItemService
{
	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<long> dto);
	/// <summary>
	/// Updates <see cref="IReceivePlannedItem"/>.
	/// </summary>
	/// <param name="args">The arguments containing the changed properties of the item.</param>
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateReceivePlannedItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IReceivePlannedItem?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("select-by-entity")]
	Task<IReceivePlannedItem?> Select(ISelectReceivePlannedItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IReceivePlannedItem>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("query-by-item")]
	Task<ImmutableList<IReceivePlannedItem>> Query(IPrimaryKeyDto<long> dto);
}