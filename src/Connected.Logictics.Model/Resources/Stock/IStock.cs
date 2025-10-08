using Connected.Entities;

namespace TomPIT.Logistics.Stock;
/// <summary>
/// The stock descriptor which describes what kind of entity it
/// represents. The entity could be Product, Semi product or any
/// other type of entity.
/// </summary>
public interface IStock : IEntity<long>
{
	/// <summary>
	/// The type of the entity.
	/// </summary>
	string Entity { get; init; }
	/// <summary>
	/// The primary key of the entity.
	/// </summary>
	string EntityId { get; init; }
	/// <summary>
	/// The total quantity currently available.
	/// </summary>
	float Quantity { get; init; }
	/// <summary>
	/// The minimum quantity that should be always available
	/// in the stock.
	/// </summary>
	float? Min { get; init; }
	/// <summary>
	/// The maximum quantity that should be stored in
	/// the stock.
	/// </summary>
	float? Max { get; init; }
}
