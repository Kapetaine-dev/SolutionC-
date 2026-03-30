using FileConvertor.Models;

namespace FileConvertor.Interfaces;

public interface IWriter
{
    void Write(string path, List<Data> lines, List<string> selectedFields);
}