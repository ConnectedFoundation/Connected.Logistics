using Connected.Annotations.Entities;
using Connected.Logictics.Documents.Receive;
using Connected.Logictics.Documents.Receive.Items;

namespace Connected.Logictics.Documents;
public static class MetaData
{
	public const string ReceiveDocumentKey = $"{SchemaAttribute.LogisticsSchema}.{nameof(IReceiveDocument)}";
	public const string ReceiveItemKey = $"{SchemaAttribute.LogisticsSchema}.{nameof(IReceiveItem)}";
}
