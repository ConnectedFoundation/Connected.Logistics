using Connected.Caching;

namespace Connected.Logictics.Documents.Receive;
internal class ReceiveDocumentCache(ICachingService cachingService)
	: CacheContainer<ReceiveDocument, int>(cachingService, MetaData.ReceiveDocumentKey), IReceiveDocumentCache
{
}
