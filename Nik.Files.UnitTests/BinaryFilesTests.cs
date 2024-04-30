namespace Nik.Files.UnitTests;

public sealed class BinaryFilesTests
{
    [Fact]
    public async Task TestPdfFileAsync()
    {
        const string SourcePictureDocumentpdf = @"TestPictureDocument.pdf";
        const string TargetPictureDocumentpdf = @"TestPictureDocument-target.pdf";
        const string SourceTextDocumentpdf = @"TestTextDocument.pdf";
        const string TargetTextDocumentpdf = @"TestTextDocument-target.pdf";

        BinaryFileReader binaryFileReader = new();
        var binaryContent = await binaryFileReader.GetFileContentAsync(SourcePictureDocumentpdf);

        BinaryFileWriter binaryFileWriter = new();
        await binaryFileWriter.WriteContentAsync(TargetPictureDocumentpdf, binaryContent);

        FileInfo sourceFileInfo = new(SourcePictureDocumentpdf);
        FileInfo targetFileInfo = new(TargetPictureDocumentpdf);
        sourceFileInfo.Length.Should().Be(targetFileInfo.Length);

        var base64Content = Convert.ToBase64String(await binaryFileReader.GetFileContentAsync(SourceTextDocumentpdf));
        await binaryFileWriter.WriteContentAsync(TargetTextDocumentpdf, Convert.FromBase64String(base64Content));

        sourceFileInfo = new(SourceTextDocumentpdf);
        targetFileInfo = new(TargetTextDocumentpdf);
        sourceFileInfo.Length.Should().Be(targetFileInfo.Length);
    }
}