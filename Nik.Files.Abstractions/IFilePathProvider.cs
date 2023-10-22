namespace Nik.Files.Abstractions;

public interface IFilePathProvider
{
    string GetFullPath(string path);
}
