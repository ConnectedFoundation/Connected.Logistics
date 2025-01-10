using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Statistics.Ops;
internal class Select(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyDto<int>, IReceiveDocumentStatistics?>
{
	protected override async Task<IReceiveDocumentStatistics?> OnInvoke()
	{
		return await storage.Open<ReceiveDocumentStatistics>().AsEntity(f => f.Id == Dto.Id);
	}
}