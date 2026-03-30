using Connected.Annotations.Entities;
using Connected.Collections.Queues;

namespace Connected.Logictics.Resources.Stock.Aggregations;

[Table(Schema = SchemaAttribute.LogisticsSchema)]
internal sealed record StockQueueMessage
	: QueueMessage
{
}
