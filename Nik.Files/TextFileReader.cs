namespace Nik.Files;

public sealed class TextFileReader : ITextFileReader
{
    public async Task<string> ReadAsync(string fileName, Encoding encoding)
    {
        using StreamReader streamReader = new(fileName, encoding);

        var result = await streamReader.ReadToEndAsync();
        streamReader.Close();

        return result;
    }

    public Task<string> ReadAsync(string fileName) =>
        ReadAsync(fileName, Encoding.UTF8);

    public async Task<string[]> ReadLinesAsync(string fileName, Encoding encoding) =>
       (await ReadAsync(fileName, encoding))
        .Split(Environment.NewLine);

    public Task<string[]> ReadLinesAsync(string fileName) => ReadLinesAsync(fileName, Encoding.UTF8);
}