using PhoneNumbers;

namespace TypeSystems.Models;

public class PhoneNumber
{
    private static readonly PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
    private readonly PhoneNumbers.PhoneNumber? _parsedPhoneNumber;

    public readonly string? OriginalPhoneNumber = string.Empty;
    public readonly NumberParseException? ParsingException;

    public bool IsEmpty => OriginalPhoneNumber == null;
    public bool IsValid => _parsedPhoneNumber != null && ParsingException is not null && phoneNumberUtil.IsValidNumber(_parsedPhoneNumber);

    public PhoneNumber()
    {
        ParsingException = new NumberParseException(ErrorType.NOT_A_NUMBER, "Phone number is empty");
    }

    public PhoneNumber(string? phoneNumber)
    {
        OriginalPhoneNumber = phoneNumber;
        try
        {
            _parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);
        }
        catch (NumberParseException ex)
        {
            ParsingException = ex;
        }
    }

    public override string ToString() => _parsedPhoneNumber switch
    {
        null => OriginalPhoneNumber ?? string.Empty,
        _ => IsValid
            ? phoneNumberUtil.Format(_parsedPhoneNumber, PhoneNumberFormat.INTERNATIONAL)
            : OriginalPhoneNumber ?? string.Empty
    };

    public override bool Equals(object? obj) => obj is PhoneNumber phoneNumber && ToString() == phoneNumber.ToString();
    public override int GetHashCode() => ToString().GetHashCode();
}
