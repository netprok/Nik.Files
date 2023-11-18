namespace Nik.Files;

public sealed class FilePathProvider : IFilePathProvider
{
    public string GetFullPath(string path)
    {
        path = path.TrimStart("/".ToCharArray()).TrimStart(@"\".ToCharArray());

        return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, path);
    }
}