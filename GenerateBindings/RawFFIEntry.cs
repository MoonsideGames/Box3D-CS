using System.Text.Json.Serialization;

namespace GenerateBindings;

internal class RawFFIEntry
{
    [JsonPropertyName("tag")]
    public string Tag { get; }

    [JsonPropertyName("id")]
    public uint? ID { get; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("location")]
    public string? Header { get; }

    [JsonPropertyName("type")]
    public RawFFIEntry? Type { get; }

    [JsonPropertyName("fields")]
    public RawFFIEntry[]? Fields { get; }

    [JsonPropertyName("value")]
    public uint? Value { get; }

    [JsonPropertyName("parameters")]
    public RawFFIEntry[]? Parameters { get; }

    [JsonPropertyName("return-type")]
    public RawFFIEntry? ReturnType { get; }

    [JsonPropertyName("size")]
    public uint? Size { get; }

    [JsonPropertyName("bit-offset")]
    public uint? BitOffset { get; }

    [JsonPropertyName("bit-size")]
    public uint? BitSize { get; }

    [JsonPropertyName("width")]
    public uint? Width { get; }

    [JsonConstructor]
    public RawFFIEntry(
        string tag,
        uint? id,
        string? name,
        string? header,
        RawFFIEntry? type,
        RawFFIEntry[]? fields,
        uint? value,
        RawFFIEntry[]? parameters,
        RawFFIEntry? returnType,
        uint? size,
        uint? bitOffset,
        uint? bitSize,
        uint? width
    )
    {
        Tag = tag.Replace(":", "");
        ID = id;
        Name = name;
        Header = header;
        Type = type;
        Fields = fields;
        Value = value;
        Parameters = parameters;
        ReturnType = returnType;
        Size = size;
        BitOffset = bitOffset;
        BitSize = bitSize;
        Width = width;
    }
}
