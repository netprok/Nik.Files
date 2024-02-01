namespace Nik.Files;

public sealed class BinaryFileReader : IBinaryFileReader
{
    public async Task<byte[]> GetFileContentAsync(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return [];
        }

        using FileStream fileStream = new(fileName, FileMode.Open);
        using MemoryStream memoryStream = new();
        await fileStream.CopyToAsync(memoryStream);
        fileStream.Close();
        var result = memoryStream.ToArray();
        memoryStream.Close();
        return result;
    }
}