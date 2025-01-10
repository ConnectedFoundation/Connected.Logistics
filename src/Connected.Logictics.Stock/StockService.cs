using Connected.Logictics.Stock.Ops;
using Connected.Services;
using System.Collections.Immutable;
using TomPIT.Logistics.Stock;

namespace Connected.Logictics.Stock;

internal sealed class StockService(IServiceProvider services)
	: Service(services), IStockService
{
	public Task<ImmutableList<IStockItem>> QueryItems(IPrimaryKeyDto<long> dto)
	{
		throw new NotImplementedException();
	}

	public Task<ImmutableList<IStockItem>> QueryItems(IQueryStockItemsDto dto)
	{
		throw new NotImplementedException();
	}

	public Task<IStock?> Select(IPrimaryKeyDto<long> dto)
	{
		throw new NotImplementedException();
	}

	public Task<IStock?> Select(IEntityDto dto)
	{
		throw new NotImplementedException();
	}

	public Task<IStockItem?> SelectItem(IPrimaryKeyDto<long> dto)
	{
		throw new NotImplementedException();
	}

	public async Task Update(IUpdateStockDto dto)
	{
		await Invoke(GetOperation<UpdateStock>(), dto);
	}
}
