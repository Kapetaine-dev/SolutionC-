using System.Text.Json;
using FileConvertor.Interfaces;
using FileConvertor.Models;

namespace FileConvertor.Services;

public class JsonWriter : IWriter
{
    public void Write(string path, List<Data> lines, List<string> selectedFields)
    {
        var filtered = lines
            .Select(line => selectedFields.ToDictionary(f => f, f => line.Fields.GetValueOrDefault(f, "")));

        var json = JsonSerializer.Serialize(filtered, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}