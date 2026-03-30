using FileConvertor.Interfaces;
using FileConvertor.Models;

namespace FileConvertor.Services;

public class CsvReader : IReader
{
    public List<Data> Read(string path)
    {
        var allLines = File.ReadAllLines(path);
        var headers = allLines[0].Split(',');

        return allLines.Skip(1)
            .Select(line => new Data
            {
                Fields = headers
                    .Zip(line.Split(','), (header, value) => new { header, value })
                    .ToDictionary(x => x.header.Trim(), x => x.value.Trim())
            })
            .ToList();
    }

    public List<string> GetHeaders(string path) =>
        File.ReadLines(path).First().Split(',').Select(h => h.Trim()).ToList();
}