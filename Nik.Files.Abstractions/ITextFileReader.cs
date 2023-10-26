namespace Nik.Files.Abstractions;

public interface ITextFileReader
{
    string Read(string fileName, Encoding encoding);

    string Read(string fileName);

    string[] ReadLines(string fileName, Encoding encoding);

    string[] ReadLines(string fileName);
}