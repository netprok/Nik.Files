namespace Nik.Files;

public static class ServicesExtensions
{
    public static IServiceCollection UseFiles(this IServiceCollection services)
    {
        services.AddSingleton<ICsvJoiner, CsvJoiner>();
        services.AddSingleton<IFileNameGenerator, FileNameGenerator>();
        services.AddSingleton<IFilePathProvider, FilePathProvider>();
        services.AddSingleton<IFileArchiver, MoveToFolderFileArchiver>();
        return services;
    }
}