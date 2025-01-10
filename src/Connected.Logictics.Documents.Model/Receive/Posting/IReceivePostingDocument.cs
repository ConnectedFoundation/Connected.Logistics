using Connected.Documents;

namespace Connected.Logictics.Documents.Receive.Posting;

public interface IReceivePostingDocument : IDocument<int>
{
	int Head { get; init; }
}
