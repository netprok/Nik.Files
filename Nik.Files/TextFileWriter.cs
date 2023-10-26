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
}