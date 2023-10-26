namespace Nik.Files;

public sealed class TextFileReader : ITextFileReader
{
    public string Read(string fileName, Encoding encoding)
    {
        using StreamReader streamReader = new(fileName, encoding);

        var result = streamReader.ReadToEnd();
        streamReader.Close();

        return result;
    }

    public string Read(string fileName) => Read(fileName, Encoding.UTF8);

    public string[] ReadLines(string fileName, Encoding encoding) => Read(fileName, encoding).Split(Environment.NewLine);

    public string[] ReadLines(string fileName) => ReadLines(fileName, Encoding.UTF8);
}