namespace Nik.Nik.Files.UnitTests.UnitTests;

public sealed class TextFilesTests
{
    [Fact]
    public async Task TestTextFileAsync()
    {
        string fileName = Path.GetTempFileName();

        TextFileWriter textFileWriter = new();
        var sourceContent = new RandomTextGenerator().GenerateRandomText(1000);
        await textFileWriter.WriteAsync(fileName, sourceContent);

        TextFileReader textFileReader = new();
        var writtenContent = await textFileReader.ReadAsync(fileName);

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        writtenContent.Should().Be(sourceContent);
    }
}