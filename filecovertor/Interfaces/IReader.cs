using FileConvertor.Models;

namespace FileConvertor.Interfaces;

public interface IReader
{
    List<Data> Read(string path);
    List<string> GetHeaders(string path);
}