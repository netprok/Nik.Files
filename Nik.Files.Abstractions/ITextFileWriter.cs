
namespace Nik.Files.Abstractions;

public interface ITextFileWriter
{
    Task WriteAsync(string fileName, string content, Encoding encoding);

    Task WriteAsync(string fileName, string content);

    Task WriteLinesAsync(string fileName, string[] lines, Encoding encoding);

    Task WriteLinesAsync(string fileName, string[] lines);
}