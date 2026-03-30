using System.Text.Json;
using FileConvertor.Interfaces;
using FileConvertor.Models;

namespace FileConvertor.Services;

public class JsonReader : IReader
{
    public List<Data> Read(string path)
    {
        var json = File.ReadAllText(path);
        var rawList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json) ?? new();

        return rawList
            .Select(dict => new Data { Fields = dict })
            .ToList();
    }

    public List<string> GetHeaders(string path)
    {
        var lines = Read(path);
        return lines.FirstOrDefault()?.Fields.Keys.ToList() ?? new();
    }
}