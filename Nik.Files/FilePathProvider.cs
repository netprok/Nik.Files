using Nik.Files.Abstractions;
namespace Nik.Files;

public sealed class FilePathProvider : IFilePathProvider
{
    public string GetFullPath(string path)
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, path);
    }
}
