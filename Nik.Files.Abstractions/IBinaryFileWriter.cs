namespace Nik.Files.Abstractions;

public interface IBinaryFileWriter
{
    Task WriteContentAsync(string fileName, byte[] content);
}