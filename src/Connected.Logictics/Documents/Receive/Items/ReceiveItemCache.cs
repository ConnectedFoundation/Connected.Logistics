using Connected.Caching;

namespace Connected.Logictics.Documents.Receive.Items;
internal class ReceiveItemCache(ICachingService cachingService)
	: CacheContainer<ReceiveItem, long>(cachingService, MetaData.ReceiveItemKey), IReceiveItemCache
{
}
