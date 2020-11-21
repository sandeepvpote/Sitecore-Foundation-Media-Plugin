using Sitecore.Diagnostics;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Foundation.MediaPlugin.Utilities
{
    public class UploadMediaForm : Sitecore.Shell.Applications.Media.UploadMedia.UploadMediaForm
    {
        protected new void ShowFileTooBig(string filename)
        {
            Assert.ArgumentNotNullOrEmpty(filename, nameof(filename));

            SheerResponse.Alert(UploadFileSettings.FileErrorMessage(filename));
            this.OK.Disabled = true;
            this.Cancel.Disabled = true;
            this.OK.Disabled = false;
            this.Cancel.Disabled = false;
        }
    }
}