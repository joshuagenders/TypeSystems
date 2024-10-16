﻿using System.Text.Json.Serialization;
using TypeSystems.Converters;

namespace TypeSystems.Models;

public class User
{
    public string Name { get; set; } = string.Empty;

    [JsonConverter(typeof(PhoneNumberConverter))]
    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber(string.Empty);
}
