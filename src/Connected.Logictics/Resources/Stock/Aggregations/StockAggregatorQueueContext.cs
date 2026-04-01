using Connected.Collections.Queues;
using Connected.Logictics.Resources.Stock.Aggregations;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Stock.Aggregations;

internal sealed class StockAggregatorQueueContext(IStorageProvider storage, IQueueMessageCache cache)
		: QueueContext<StockQueueMessage, StockAggregatorQueueAction, IPrimaryKeyDto<long>>(storage, cache)
{
}
