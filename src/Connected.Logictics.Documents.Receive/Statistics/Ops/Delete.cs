using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Statistics.Ops;
internal class Delete(IStorageProvider storage, IReceiveDocumentStatisticsService statistics, IEventService events)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await statistics.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocumentStatistics) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ReceiveDocumentStatistics>().Update(Dto.AsEntity<ReceiveDocumentStatistics>(State.Deleted));
		await events.Deleted(this, statistics, Dto.Id);
	}
}
