using Connected.Entities;

namespace TomPIT.Logistics.Stock.Aggregations;

public interface IStockAggregation : IEntity<long>
{
	long Stock { get; init; }
	DateTimeOffset Date { get; init; }
	float Quantity { get; init; }
}
