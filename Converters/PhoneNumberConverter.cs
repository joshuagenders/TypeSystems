using System.Text.Json;
using System.Text.Json.Serialization;

namespace TypeSystems;

public class PhoneNumberConverter : JsonConverter<PhoneNumber>
{
    public override PhoneNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var phoneNumber = reader.GetString();
        if (phoneNumber is null)
        {
            throw new JsonException();
        }
        return new PhoneNumber(phoneNumber);
    }

    public override void Write(Utf8JsonWriter writer, PhoneNumber value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
