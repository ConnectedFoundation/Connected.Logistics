using Connected.Entities;
using Connected.Services;

namespace Connected.Logistics.Types.SerialNumbers.Dtos;

/// <summary>
/// The arguments used when updating the existing serial entity.
/// </summary>
public interface IUpdateSerialNumberDto : IPrimaryKeyDto<long>
{
	/// <summary>
	/// The new quantity. This is an absolute value, do not provide
	/// delta values.
	/// </summary>
	float Quantity { get; set; }
	/// <inheritdoc cref="ISerial.BestBefore"/>
	DateTimeOffset? BestBefore { get; set; }
	/// <inheritdoc cref="ISerial.Status"/>
	Status Status { get; set; }
}
