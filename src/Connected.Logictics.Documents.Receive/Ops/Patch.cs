using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;

namespace Connected.Logictics.Documents.Receive.Ops;
internal class Patch(IReceiveDocumentService documents)
	: ServiceAction<IPatchDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = await documents.Select(Dto.AsDto<IPrimaryKeyDto<int>>()) as ReceiveDocument ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await documents.Update(Dto.Patch<IUpdateReceiveDocumentDto, ReceiveDocument>(entity));
	}
}
