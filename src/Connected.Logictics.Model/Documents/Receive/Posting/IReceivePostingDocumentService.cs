using Connected.Annotations;
using Connected.Logictics.Documents.Receive;
using Connected.Logictics.Documents.Receive.Posting.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive.Posting;

/// <summary>
/// Represents service for the <see cref="IReceivePostingDocument"/> document.
/// </summary>
[Service, ServiceUrl(Urls.ReceivePostingDocuments)]
public interface IReceivePostingDocumentService
{
	/// <summary>
	/// Inserts a new <see cref="IReceivePostingDocument"/>.
	/// </summary>
	/// <param name="args">The arguments containing the properties of the new document.</param>
	/// <returns>The id of the newly inserted document.</returns>
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertReceivePostingDocumentDto dto);
	/// <summary>
	/// Updates <see cref="IReceivePostingDocument"/> document.
	/// </summary>
	/// <param name="args">The arguments containing changed properties of the document.</param>
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateReceivePostingDocumentStatisticsDto dto);
	/// <summary>
	/// Performs partial update on the <see cref="IReceivePostingDocument"/> for the properties specified 
	/// in arguments.
	/// </summary>
	/// <param name="args">The arguments containing properties that need to be updated.</param>
	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);
	/// <summary>
	/// Deletes <see cref="IReceivePostingDocument"/> from the storage.
	/// </summary>
	/// <param name="args">The arguments containing the id of the document that is about to be deleted.</param>
	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Selects <see cref="IReceivePostingDocument"/> for the specified id.
	/// </summary>
	/// <param name="args">The arguments containing the id.</param>
	/// <returns><see cref="IReceivePostingDocument"/> is found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IReceivePostingDocument?> Select(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Queries <see cref="IReceivePostingDocument"/> for the specified <see cref="IReceiveDocument"/> document.
	/// </summary>
	/// <param name="args">The arguments containing the id of the parent receive document.</param>
	/// <returns><see cref="IReceivePostingDocument"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IReceivePostingDocument>> Query(IHeadDto<int> dto);
}
