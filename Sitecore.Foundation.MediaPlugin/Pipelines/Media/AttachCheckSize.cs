using Sitecore.Pipelines.Attach;
using System.Web;
using Sitecore.Foundation.MediaPlugin.Utilities;

namespace Sitecore.Foundation.MediaPlugin.Pipelines.Media
{
    public class AttachCheckSize
    {
        public void Process(AttachArgs args)
        {
            if (UploadFileSettings.IsAllowedFile(args.FileWrapper))
                return;

            string errorMessage = UploadFileSettings.FileErrorMessage(args.FileWrapper.FileName);


            HttpContext.Current.Response.Write(
                "<html><head><script type=\"text/JavaScript\" language=\"javascript\">window.top.scForm.getTopModalDialog().frames[0].scForm.postRequest(\"\", \"\", \"\", 'ShowAlert(\"" +
                errorMessage + "\")')</script></head><body>Done</body></html>");

            args.AbortPipeline();
        }
    }
}