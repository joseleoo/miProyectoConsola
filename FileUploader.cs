using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class FileUploader
{
    public async Task UploadFileAsync(string filePath, IProgress<int> progress)
    {
        byte[] buffer = new byte[1024 * 1024]; // 1 MB chunks
        long totalBytes = new FileInfo(filePath).Length;
        long totalRead = 0;

        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            int bytesRead;
            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await Task.Delay(100); // Simulate network delay

                totalRead += bytesRead;
                int percent = (int)((double)totalRead / totalBytes * 100);
                progress?.Report(percent);
            }
        }

        Console.WriteLine("Upload completed.");
    }
}
