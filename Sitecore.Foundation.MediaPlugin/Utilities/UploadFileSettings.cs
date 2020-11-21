using Sitecore.Foundation.MediaPlugin.Repositories;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.MediaPlugin.Utilities
{
    public static class UploadFileSettings
    {
        public static bool IsAllowedFile(HttpPostedFileBase file)
        {
            var fileConfigs = MediaPluginRepository.GetMediaFileConfig();
            double fileSize = file.ContentLength.ConvertBytesToMegabytes();

            var fileAllowed = fileConfigs.SingleOrDefault(k => k.Extension == file.FileName.FileExtensionWithoutDot());

            return !(fileSize > System.Convert.ToDouble(fileAllowed?.SizeAllowed));
        }

        public static bool IsAllowedFile(HttpPostedFile file)
        {
            var fileConfigs = MediaPluginRepository.GetMediaFileConfig();
            double fileSize = file.ContentLength.ConvertBytesToMegabytes();

            var fileAllowed = fileConfigs.SingleOrDefault(k => k.Extension == file.FileName.FileExtensionWithoutDot());

            return !(fileSize > System.Convert.ToDouble(fileAllowed?.SizeAllowed));
        }

        public static bool IsAllowedFile(string fileName, long fileSize)
        {
            var fileConfigs = MediaPluginRepository.GetMediaFileConfig();

            var fileAllowed = fileConfigs.SingleOrDefault(k => k.Extension == fileName.FileExtensionWithoutDot());

            return !(fileSize > System.Convert.ToDouble(fileAllowed?.SizeAllowed));
        }

        public static bool CheckRestrictedFileType(string fileName)
        {
            MediaPluginRepository mediaConfig = new MediaPluginRepository();

            var fileConfigs = MediaPluginRepository.GetMediaFileConfig();

            var fileAllowed = fileConfigs.SingleOrDefault(k => k.Extension == fileName.FileExtensionWithoutDot());

            return (fileAllowed == null);
        }

        public static int RestrictedFileSize(string fileName)
        {
            MediaPluginRepository mediaConfig = new MediaPluginRepository();

            var fileConfigs = MediaPluginRepository.GetMediaFileConfig();

            var fileAllowed = fileConfigs.SingleOrDefault(k => k.Extension == fileName.FileExtensionWithoutDot());
            if (fileAllowed == null) return 0;

            return fileAllowed.SizeAllowed;
        }

        public static string FileErrorMessage(string filename)
        {
            return CheckRestrictedFileType(filename)
                ? $"{filename} cannot be uploaded. File type is restricted."
                : $"The {filename} is too big to be uploaded. The maximum size for uploading file is {RestrictedFileSize(filename)} MB.";
        }
    }
}