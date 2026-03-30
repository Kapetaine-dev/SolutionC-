using FileConvertor.Models;

namespace FileConvertor.Services;

public class DataService
{
    public List<Data> Search(List<Data> data, string keyword) =>
        data.Where(line =>
            line.Fields.Values.Any(v => v.Contains(keyword, StringComparison.OrdinalIgnoreCase))
        ).ToList();

    public List<Data> Sort(List<Data> data, string field, bool ascending = true) =>
        ascending
            ? data.OrderBy(line => line.Fields.GetValueOrDefault(field, "")).ToList()
            : data.OrderByDescending(line => line.Fields.GetValueOrDefault(field, "")).ToList();

    public List<Data> Filter(List<Data> data, string field, string value) =>
        data.Where(line =>
            line.Fields.GetValueOrDefault(field, "")
                .Equals(value, StringComparison.OrdinalIgnoreCase)
        ).ToList();

    public void Display(List<Data> data, List<string> headers)
    {
        Console.WriteLine(string.Join(" | ", headers));
        Console.WriteLine(new string('-', headers.Count * 20));

        foreach (var line in data.Select(line => string.Join(" | ", headers.Select(h => line.Fields.GetValueOrDefault(h, "")))))
        {
            Console.WriteLine(line);
        }
    }
}