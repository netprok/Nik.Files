namespace Nik.Files.Abstractions;

public interface IBinaryFileReader
{
    Task<byte[]> GetFileContentAsync(string fileName);
}