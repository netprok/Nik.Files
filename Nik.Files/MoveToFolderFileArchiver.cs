using Microsoft.Extensions.Logging;

namespace Nik.Files;

public sealed class MoveToFolderFileArchiver : IFileArchiver
{
    private readonly IStringFormatter stringFormatter;
    private readonly ILogger<MoveToFolderFileArchiver> logger;

    public MoveToFolderFileArchiver(
        IStringFormatter stringFormatter,
        ILogger<MoveToFolderFileArchiver> logger)
    {
        this.stringFormatter = stringFormatter;
        this.logger = logger;
    }

    public void Archive(string file, string archiveName)
    {
        logger.LogDebug($"Moving file {file} to archive folder...");
        var foldersNow = stringFormatter.GetFolderViewDateNow();

        var destinationPath = Path.Combine(Path.GetDirectoryName(file)!, archiveName, foldersNow);
        Directory.CreateDirectory(destinationPath);
        var destinationFile = GetUniqueFileName(Path.Combine(destinationPath, Path.GetFileName(file)));

        File.Move(file, destinationFile);

        logger.LogInformation($"File {file} moved to archive folder.");
    }

    private string GetUniqueFileName(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return fileName;
        }

        var newFileName = Path.GetFileNameWithoutExtension(fileName) + "__" + (string?)stringFormatter.GetSortableNow() + Path.GetExtension(fileName);
        var path = Path.GetDirectoryName(fileName);
        return Path.Combine(path!, newFileName);
    }
}