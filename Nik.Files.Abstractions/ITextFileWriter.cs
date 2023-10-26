namespace Nik.Files
{
    public interface ITextFileWriter
    {
        void Write(string fileName, string contents, Encoding encoding);

        void Write(string fileName, string contents);
    }
}