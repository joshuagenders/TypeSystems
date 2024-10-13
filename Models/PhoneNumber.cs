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

        public override string ToString()
        {
            return _parsedPhoneNumber is not null ? phoneNumberUtil.Format(_parsedPhoneNumber, PhoneNumberFormat.INTERNATIONAL) : OriginalPhoneNumber;
        }
    }
}
