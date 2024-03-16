namespace Nik.Files;

public sealed class TextFileWriter : ITextFileWriter
{
    public async Task WriteAsync(string fileName, string content, Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(fileName);
        ArgumentNullException.ThrowIfNull(content);

        var directoryName = Path.GetDirectoryName(fileName);
        if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        using FileStream stream = new(fileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);

        var encodedText = encoding.GetBytes(content);
        await stream.WriteAsync(encodedText).ConfigureAwait(false);
    }

    public Task WriteAsync(string fileName, string contents)
    {
        return WriteAsync(fileName, contents, Encoding.UTF8);
    }

    public Task WriteLinesAsync(string fileName, string[] lines, Encoding encoding)
    {
        return WriteAsync(fileName, string.Join(Environment.NewLine, lines), encoding);
    }

    public Task WriteLinesAsync(string fileName, string[] lines)
    {
        return WriteLinesAsync(fileName, lines, Encoding.UTF8);
    }
}