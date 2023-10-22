namespace Nik.Files.Abstractions;

public interface IFileNameGenerator
{
    string Generate(string path, string prefix, string extension);
}
