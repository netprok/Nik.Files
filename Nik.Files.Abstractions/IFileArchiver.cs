namespace Nik.Files.Abstractions;

public interface IFileArchiver
{
    void Archive(string file, string archiveName);
}
