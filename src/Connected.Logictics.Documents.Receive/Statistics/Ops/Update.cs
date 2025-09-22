using Connected.Entities;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Logictics.Documents.Receive.Statistics.Ops;
internal class Update(IStorageProvider storage, IReceiveDocumentStatisticsService statistics, IEventService events) : ServiceAction<IUpdateReceiveDocumentStatisticsDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await statistics.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocumentStatistics);

		if (entity is null)
		{
			await storage.Open<ReceiveDocumentStatistics>().Update(Dto.AsEntity<ReceiveDocumentStatistics>(State.Add));

			await events.Inserted(this, statistics, Dto.Id);
		}
		else
		{
			entity = await storage.Open<ReceiveDocumentStatistics>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
			{
				return SetState(await statistics.Select(Dto.AsDto<IPrimaryKeyDto<int>>())) as ReceiveDocumentStatistics;
			}, Caller);

			await events.Updated(this, statistics, Dto.Id);
		}
	}
}
