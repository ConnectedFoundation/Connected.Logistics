using Connected.Services;

namespace Connected.Logistics.Types.SerialNumbers.Dtos;

/// <summary>
/// The arguments used for selecting serial by its value.
/// </summary>
public interface ISelectSerialNumberDto : IDto
{
	/// <inheritdoc cref="ISerial.Value"/>
	string Value { get; set; }
}