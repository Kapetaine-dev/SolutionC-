using FileConvertor.Interfaces;
using FileConvertor.Models;
using FileConvertor.Services;

namespace FileConvertor;

public class ConvertorManager
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly DataService dataService;

    private List<Data> loadedData = new();
    private List<string> headers = new();

    public ConvertorManager(IReader reader, IWriter writer, DataService dataService)
    {
        this.reader = reader;
        this.writer = writer;
        this.dataService = dataService;
    }

    public void Load(string sourcePath)
    {
        headers = reader.GetHeaders(sourcePath);
        loadedData = reader.Read(sourcePath);
        Console.WriteLine($"{loadedData.Count} lignes chargées.");
    }

    public void Preview(string? keyword = null, string? sortField = null, bool ascending = true)
    {
        var result = loadedData;

        if (!string.IsNullOrEmpty(keyword))
            result = dataService.Search(result, keyword);

        if (!string.IsNullOrEmpty(sortField))
            result = dataService.Sort(result, sortField, ascending);

        dataService.Display(result, headers);
    }

    public void Export(string targetPath, List<string>? selectedFields = null)
    {
        var fields = selectedFields ?? headers;
        writer.Write(targetPath, loadedData, fields);
        Console.WriteLine($"Export terminé : {targetPath}");
    }

    public List<string> GetHeaders() => headers;
}