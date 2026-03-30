using FileConvertor.Interfaces;
using FileConvertor.Models;

namespace FileConvertor.Services;

public class CsvWriter : IWriter
{
    public void Write(string path, List<Data> lines, List<string> selectedFields)
    {
        var header = string.Join(",", selectedFields);
        var rows = lines.Select(line =>
            string.Join(",", selectedFields.Select(f => line.Fields.GetValueOrDefault(f, "")))
        );

        File.WriteAllLines(path, new[] { header }.Concat(rows));
    }
}
