using Connected.Entities;

namespace Connected.Logistics.Types.SerialNumbers;
/// <summary>
/// Represents a serial number in the logistic environment.
/// </summary>
/// <remarks>
/// The primary usage of the Serial is in warehouse management
/// system, where every item in the stock is labeled with serial number.
/// Once the item is received and before it is put in the stock locations,
/// it receives a unique serial number. If the item is moved between stock
/// locations and even warehouses, its serial value remains the same. Serial
/// number plays a key role in traceability.
/// </remarks>
public interface ISerialNumber : IEntity<long>
{
	/// <summary>
	/// The entity which owns the serial number. This could 
	/// be Product, Semi product, Raw or any other type of
	/// entity which needs some kind of labeling.
	/// </summary>
	string Entity { get; init; }
	/// <summary>
	/// The primary key of the entity. This points to the exact record of
	/// the Entity type.
	/// </summary>
	string EntityId { get; init; }
	/// <summary>
	/// The actual Serial number. System can use different middleware techniques
	/// to obtain this value because it's very common to be have project specific
	/// implementation to calculate this value.
	/// </summary>
	string Value { get; init; }
	/// <summary>
	/// The remaining quantity in the stock for this serial. This value can increase
	/// or decrease depending on the warehouse implementation. Some systems do reuse
	/// the same serial between different receives.
	/// </summary>
	float Quantity { get; init; }
	/// <summary>
	/// The date serial was created.
	/// </summary>
	DateTimeOffset Created { get; init; }
	/// <summary>
	/// If the item has limited shelf life, this value should hold the date when
	/// the shelf life expires.
	/// </summary>
	DateTimeOffset? BestBefore { get; init; }
	/// <summary>
	/// The status of the serial number. If the status is <see cref="Status.Disabled"/> the
	/// processes using the serial number should not allow the entity to be used in documents.
	/// </summary>
	Status Status { get; init; }
}
