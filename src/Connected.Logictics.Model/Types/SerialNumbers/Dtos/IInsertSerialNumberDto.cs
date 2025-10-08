using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Logistics.Types.SerialNumbers.Dtos;

/// <summary>
/// Arguments used when inserting a new serial number.
/// </summary>
public interface IInsertSerialNumberDto : IDto
{
	/// <inheritdoc cref="ISerial.Entity"/>
	[Required, MaxLength(128)]
	string Entity { get; set; }
	/// <inheritdoc cref="ISerial.EntityId"/>
	[Required, MaxLength(128)]
	string EntityId { get; set; }
	/// <inheritdoc cref="ISerial.Quantity"/>
	float Quantity { get; set; }
	/// <inheritdoc cref="ISerial.Created"/>
	/// <remarks>
	/// If this property is null, the process will most likely
	/// set the value of the current date (DateTime.UtcNow).
	/// </remarks>
	DateTimeOffset? Created { get; set; }
	/// <inheritdoc cref="ISerial.BestBefore"/>
	DateTimeOffset? BestBefore { get; set; }
	/// <inheritdoc cref="ISerial.Status"/>
	Status Status { get; set; }
	/// <inheritdoc cref="ISerial.Value"/>
	string Value { get; set; }
}
