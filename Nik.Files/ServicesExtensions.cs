namespace Nik.Files;

public static class ServicesExtensions
{
    public static IServiceCollection AddNikFiles(this IServiceCollection services)
    {
        services.AddSingleton<ICsvJoiner, CsvJoiner>();
        services.AddSingleton<IFileNameGenerator, FileNameGenerator>();
        services.AddSingleton<IFilePathProvider, FilePathProvider>();
        services.AddSingleton<IFileArchiver, MoveToFolderFileArchiver>();
        services.AddSingleton<ITextFileReader, TextFileReader>();
        services.AddSingleton<ITextFileWriter, TextFileWriter>();
        services.AddSingleton<IBinaryFileReader, BinaryFileReader>();
        return services;
    }
}