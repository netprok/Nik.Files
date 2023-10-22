using Nik.Files.Abstractions;
namespace Nik.Files;

public sealed class CsvJoiner : ICsvJoiner
{
    public IEnumerable<string> Join(List<string> contents, CsvSerializeOptions csvSerializeOptions)
    {
        string header = string.Empty;

        foreach (string content in contents)
        {
            var csvLines = content.Split(Environment.NewLine).ToList();
            if (csvSerializeOptions.HasHeader)
            {
                if (string.IsNullOrEmpty(header))
                {
                    header = csvLines[0];
                    yield return header;
                }
                else
                {
                    if (csvLines[0] != header)
                    {
                        throw new Exception("Csv file headers are not identical.");
                    }
                }

                csvLines.RemoveAt(0);
            }

            yield return string.Join(Environment.NewLine, csvLines);
        }
    }
}
