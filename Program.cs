public class Program
{
    private const string FILEPATH = "large_file.txt";

    public static async Task Main()
    {
        var uploader = new FileUploader();
        var progress = new Progress<int>(percent => Console.WriteLine($"Progress: {percent}%"));

        await uploader.UploadFileAsync(FILEPATH, progress);

        Console.WriteLine("Done!");
    }
}
