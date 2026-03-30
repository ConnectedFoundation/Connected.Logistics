using Connected.Collections.Queues;

namespace Connected.Logictics.Resources.Stock.Aggregations;

internal sealed class StockQueueHost
	: QueueHost<StockQueueMessage, StockQueueCache>
{
}
