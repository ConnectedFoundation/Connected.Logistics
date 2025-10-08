using Connected.Annotations;
using Connected.Logistics.Types.SerialNumbers.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Logistics.Types.SerialNumbers;
/// <summary>
/// The service for manipulating with serial numbers. A <see cref="ISerialNumber"/> is a fundamental
/// entity used by labeling and traceability systems.
/// </summary>
[Service, ServiceUrl(Urls.SerialNumbers)]
public interface ISerialNumberService
{
	/// <summary>
	/// Queries all serial numbers.
	/// </summary>
	/// <param name="dto">The optional arguments specifiying the
	/// behavior of the result set.</param>
	/// <returns>A list of <see cref="ISerialNumber"/> entities.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<ISerialNumber>> Query(IQueryDto? dto);
	/// <summary>
	/// Performs a lookup on the serial numbers for the specified set of ids.
	/// </summary>
	/// <param name="dto">The arguments containing the list of ids for
	/// which the entities will be returned.</param>
	/// <returns>A list of entities that matches the specified ids.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<ISerialNumber>> Query(IPrimaryKeyListDto<long> dto);
	/// <summary>
	/// Returns the first serial that matches the specified id.
	/// </summary>
	/// <param name="dto">The arguments containing the id of the entity.</param>
	/// <returns>The <see cref="ISerialNumber"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ISerialNumber?> Select(IPrimaryKeyDto<long> dto);
	/// <summary>
	/// Returns the first serial with the specified value.
	/// </summary>
	/// <param name="dto">The arguments containing the value for which serial
	/// entity will be returned.</param>
	/// <returns>The <see cref="ISerialNumber"/> if found, <c>null</c> otherwise.</returns>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ISerialNumber?> Select(ISelectSerialNumberDto dto);
	/// <summary>
	/// Inserts a new serial number.
	/// </summary>
	/// <param name="args">The arguments containing the properties of the new serial.</param>
	/// <returns>The id of the newly inserted serial.</returns>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertSerialNumberDto dto);
	/// <summary>
	/// Updates an existing serial.
	/// </summary>
	/// <param name="args">The arguments containing properties which will change the entity.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Update(IUpdateSerialNumberDto dto);
	/// <summary>
	/// Performs a partial update on the serial.
	/// </summary>
	/// <param name="args">The arguments containing properties which has to be updated.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<long> dto);
	/// <summary>
	/// Peranently deletes the serial from the storage.
	/// </summary>
	/// <param name="args">The arguments containing the id of the entity to be deleted.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);
}
