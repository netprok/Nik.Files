namespace Nik.Files;

public sealed class BinaryFileWriter : IBinaryFileWriter
{
    public async Task WriteContentAsync(string fileName, byte[] content)
    {
        FileStream fileStream = new(fileName, FileMode.Create);
        MemoryStream memoryStream = new(content);
        await memoryStream!.CopyToAsync(fileStream);
    }
}