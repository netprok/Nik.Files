namespace Nik.Files;

public sealed class FileNameGenerator(
    IStringFormatter stringFormatter
    ) : IFileNameGenerator
{
    public string Generate(string path, string prefix, string extension)
    {
        if (extension.StartsWith("."))
        {
            extension = extension[1..];
        }

        Directory.CreateDirectory(path);

    CREATE_NEW:
        var name = $"{prefix}_{stringFormatter.GetSortableNow()}_{new Random().Next(1000)}.{extension}";
        string fullName = Path.Combine(path, name);
        if (File.Exists(fullName))
        {
            goto CREATE_NEW;
        }
        return fullName;
    }
}