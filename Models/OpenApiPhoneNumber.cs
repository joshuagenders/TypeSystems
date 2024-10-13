using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Writers;

namespace TypeSystems;
public class OpenApiPhoneNumber : IOpenApiPrimitive
{
    public OpenApiPhoneNumber(string value)
    {
        Value = value;
    }

    public AnyType AnyType { get; } = AnyType.Primitive;

    public PrimitiveType PrimitiveType { get; } = PrimitiveType.String;

    public string Value { get; }

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) =>
        writer.WriteValue(Value.ToString());
}