using Connected.Annotations.Entities;
using TomPIT.Logistics.Stock;

namespace Connected.Logistics.Stock;
public static class MetaData
{
	public const string StockKey = $"{SchemaAttribute.LogisticsSchema}.{nameof(IStock)}";
}
