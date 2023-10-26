namespace Nik.Files
{
    public interface ITextFileWriter
    {
        void Write(string fileName, string contents, Encoding encoding);

        void Write(string fileName, string contents);

        void WriteLines(string fileName, string[] lines, Encoding encoding);

        void WriteLines(string fileName, string[] lines);
    }
}