using Connected.Annotations.Entities;

namespace Connected.Logictics;

internal static class LogisticsMetaData
{
	public const string StockQueueMessageKey = $"{SchemaAttribute.LogisticsSchema}.{nameof(StockQueueMessageKey)}";
}
