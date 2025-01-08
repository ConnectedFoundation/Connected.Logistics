using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive;

[Service, ServiceUrl(Urls.ReceivePlannedItems)]
public interface IReceivePlannedItemService
{
	Task Patch(IPatchDto<long> dto);
	/// <summary>
	/// Updates <see cref="IReceivePlannedItem"/>.
	/// </summary>
	/// <param name="args">The arguments containing the changed properties of the item.</param>
	Task Update(IUpdateReceivePlannedItemDto dto);
	Task<IReceivePlannedItem?> Select(IPrimaryKeyDto<long> dto);
	Task<IReceivePlannedItem?> Select(ISelectReceivePlannedItemDto dto);
	Task<ImmutableList<IReceivePlannedItem>> Query(IHeadDto<int> dto);
	[ServiceUrl("query-by-item")]
	Task<ImmutableList<IReceivePlannedItem>> Query(IPrimaryKeyDto<long> dto);
}