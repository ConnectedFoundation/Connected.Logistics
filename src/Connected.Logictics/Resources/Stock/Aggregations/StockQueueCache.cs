using Connected.Caching;
using Connected.Collections.Queues;
using Connected.Storage;

namespace Connected.Logictics.Resources.Stock.Aggregations;

internal sealed class StockQueueCache(ICachingService cache, IStorageProvider storage)
	: QueueMessageCache<StockQueueMessage>(cache, storage, LogisticsMetaData.StockQueueMessageKey)
{
}
