namespace Nik.Files.Abstractions;

public interface ICsvJoiner
{
    IEnumerable<string> Join(List<string> files, CsvSerializeOptions csvSerializeOptions);
}