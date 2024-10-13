using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace TypeSystems.Models;

public class OpenApiPhoneNumber(string value) : IOpenApiPrimitive
{
    public AnyType AnyType { get; } = AnyType.Primitive;

    public PrimitiveType PrimitiveType { get; } = PrimitiveType.String;

    public string Value { get; } = value;

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) =>
        writer.WriteValue(Value.ToString());

    public static OpenApiSchema Schema =>
        new() { Type = "string", Example = new OpenApiPhoneNumber("+1234567890") };
}
