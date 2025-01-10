using Connected.Annotations;
using Connected.Logictics.Documents.Receive.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logictics.Documents.Receive;
/// <summary>
/// Represents service for the <see cref="IReceiveDocument"/> document.
/// </summary>
[Service, ServiceUrl(Urls.ReceiveDocuments)]
public interface IReceiveDocumentService
{
	/// <summary>
	/// Inserts a new <see cref="IReceiveDocument"/>.
	/// </summary>
	/// <param name="args">The arguments containing the properties of the new document.</param>
	/// <returns>The id of the newly inserted document.</returns>
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertReceiveDocumentDto dto);
	/// <summary>
	/// Updates <see cref="IReceiveDocument"/> document.
	/// </summary>
	/// <param name="args">The arguments containing changed properties of the document.</param>
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateReceiveDocumentDto dto);
	/// <summary>
	/// Performs partial update on the <see cref="IReceiveDocument"/> for the properties specified 
	/// in arguments.
	/// </summary>
	/// <param name="args">The arguments containing properties that need to be updated.</param>
	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<int> dto);
	/// <summary>
	/// Deletes <see cref="IReceiveDocument"/> from the storage.
	/// </summary>
	/// <param name="args">The arguments containing the id of the document that is about to be deleted.</param>
	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Selects <see cref="IReceiveDocument"/> for the specified id.
	/// </summary>
	/// <param name="args">The arguments containing the id.</param>
	/// <returns><see cref="IReceiveDocument"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IReceiveDocument?> Select(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Searches <see cref="IReceiveDocument">documents</see> for the specified criteria.
	/// </summary>
	/// <param name="args">The arguments containing the query criteria.</param>
	/// <returns>The list of <see cref="IReceiveDocument"/> documents that matches the search criteria.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IReceiveDocument>> Query(IQueryDto? dto);
}
