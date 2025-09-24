using System;
using System.IO;
using System.Text;

public static class FileHelper
{
    public static void SafeWriteAllText(string path, string content)
    {
        // Ensure file is writable
        if (File.Exists(path))
        {
            File.SetAttributes(path, FileAttributes.Normal);
        }

        // Write to temp file first
        string tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, content);

        // Replace original
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        File.Move(tempFile, path);

        // Force disk flush
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            fs.Flush(true);
        }
    }

    public static string SafeReadAllText(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                return sr.ReadToEnd().Trim();
            }
        }
    }
}