using Nik.Files.Abstractions;

namespace Nik.Files;

public sealed class TextFileWriter : ITextFileWriter
{
    public void Write(string fileName, string contents, Encoding encoding)
    {
        File.WriteAllText(fileName, contents, encoding);
    }

    public void Write(string fileName, string contents)
    {
        Write(fileName, contents, Encoding.UTF8);
    }

    public void WriteLines(string fileName, string[] lines, Encoding encoding)
    {
        Write(fileName, string.Join(Environment.NewLine, lines), encoding);
    }

    public void WriteLines(string fileName, string[] lines)
    {
        WriteLines(fileName, lines, Encoding.UTF8);
    }
}