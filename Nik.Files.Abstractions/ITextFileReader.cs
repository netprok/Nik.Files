namespace Nik.Files.Abstractions;

public interface ITextFileReader
{
    Task<string> ReadAsync(string fileName, Encoding encoding);

    Task<string> ReadAsync(string fileName);

    Task<string[]> ReadLinesAsync(string fileName, Encoding encoding);

    Task<string[]> ReadLinesAsync(string fileName);
}