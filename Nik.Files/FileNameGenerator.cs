using Nik.Files.Abstractions;
namespace Nik.Files;

public sealed class FileNameGenerator : IFileNameGenerator
{
    private readonly IStringFormatter stringFormatter;

    public FileNameGenerator(IStringFormatter stringFormatter)
    {
        this.stringFormatter = stringFormatter;
    }

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
