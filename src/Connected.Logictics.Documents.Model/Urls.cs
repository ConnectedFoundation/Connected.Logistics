namespace Connected.Logictics.Documents;

public static class Urls
{
	public const string Namespace = "services/logistics/documents";

	public const string ReceiveDocuments = $"{Namespace}/receives";
	public const string ReceiveItems = $"{Namespace}/receives/items";
	public const string ReceiveDocumentStatistics = $"{Namespace}/receives/statistics";
	public const string ReceivePostingDocuments = $"{Namespace}/receives/posting";
	public const string ReceivePlannedItems = $"{Namespace}/receives/planned-items";
	public const string ReceivePostingItems = $"{Namespace}/receives/posting-items";
}
