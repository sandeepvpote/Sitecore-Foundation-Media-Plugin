using Sitecore.Foundation.MediaPlugin.Models;
using System.Collections.Generic;

namespace Sitecore.Foundation.MediaPlugin.Repositories
{
    public class MediaPluginRepository
    {
        private static readonly IEnumerable<FileConfig> _mediaFileConfig = new MediaPluginConfiguration().GetMediaPluginConfiguration().FileConfig;

        public static IEnumerable<FileConfig> GetMediaFileConfig()
        {
            return _mediaFileConfig;
        }
    }
}