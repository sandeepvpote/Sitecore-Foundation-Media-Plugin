using System.IO;

namespace Sitecore.Foundation.MediaPlugin.Utilities
{
    public static class FileExtensions
    {
        public static double ConvertBytesToMegabytes(this int bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static string FileExtensionWithoutDot(this string fileName)
        {
            return string.IsNullOrWhiteSpace(fileName) ? string.Empty : Path.GetExtension(fileName).Replace(".", "");
        }
    }
}