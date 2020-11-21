using Sitecore.Diagnostics;
using Sitecore.Foundation.MediaPlugin.Utilities;
using Sitecore.Pipelines.Upload;
using Sitecore.Zip;
using System.Web;


namespace Sitecore.Foundation.MediaPlugin.Pipelines.Media
{
    public class UploadCheckSize : UploadProcessor
    {

        public void Process(UploadArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            if (args.Destination == UploadDestination.File)
                return;

            foreach (string file1 in args.Files)
            {
                HttpPostedFile file2 = args.Files[file1];
                if (!string.IsNullOrEmpty(file2.FileName))
                {
                    if (UploadProcessor.IsUnpack(args, file2))
                    {
                        ZipReader zipReader = new ZipReader(file2.InputStream);
                        try
                        {
                            foreach (ZipEntry entry in zipReader.Entries)
                            {

                                if (!entry.IsDirectory &&  ! UploadFileSettings.IsAllowedFile(entry.Name, entry.Size))
                                {
                                    string text = file2.FileName + "/" + entry.Name;
                                    args.UiResponseHandlerEx.FileTooBigForUpload(StringUtil.EscapeJavascriptString(text));
                                    args.ErrorText = UploadFileSettings.FileErrorMessage(file2.FileName);
                                    args.AbortPipeline();
                                    return;
                                }
                            }
                        }
                        finally
                        {
                            file2.InputStream.Position = 0L;
                        }
                    }
                    else if (! UploadFileSettings.IsAllowedFile(file2))
                    {
                        string fileName = file2.FileName;

                        if (HttpContext.Current.Request.Url.AbsolutePath != "/sitecore/shell/api/sitecore/Media/Upload")
                        {
                            args.UiResponseHandlerEx.FileTooBigForUpload(StringUtil.EscapeJavascriptString(fileName));
                        }
                        args.ErrorText = UploadFileSettings.FileErrorMessage(file2.FileName);
                        args.AbortPipeline();
                        break;
                    }
                }
            }
        }
    }
}