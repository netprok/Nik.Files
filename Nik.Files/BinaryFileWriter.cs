namespace Nik.Files;

public sealed class BinaryFileWriter : IBinaryFileWriter
{
    public async Task WriteContentAsync(string fileName, byte[] content)
    {
        using FileStream fileStream = new(fileName, FileMode.Create);
        using MemoryStream memoryStream = new(content);
        await memoryStream!.CopyToAsync(fileStream);
        fileStream.Close();
        memoryStream.Close();
    }
}