using PhoneNumbers;

namespace TypeSystems
{
    public class PhoneNumber
    {
        private static readonly PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        public readonly string OriginalPhoneNumber;
        private PhoneNumbers.PhoneNumber? _parsedPhoneNumber;
        public readonly Exception? ParsingException;

        public PhoneNumber()
        {
            OriginalPhoneNumber = string.Empty;
            ParsingException = new NumberParseException(ErrorType.NOT_A_NUMBER, "Phone number is empty");
        }

        public PhoneNumber(string phoneNumber)
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
            null => OriginalPhoneNumber,
            _ => phoneNumberUtil.Format(_parsedPhoneNumber, PhoneNumberFormat.INTERNATIONAL)
        };

        public override bool Equals(object? obj) => obj is PhoneNumber phoneNumber && ToString() == phoneNumber.ToString();
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
