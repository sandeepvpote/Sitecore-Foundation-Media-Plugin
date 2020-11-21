using Sitecore.Configuration;
using Sitecore.Foundation.MediaPlugin.Models;
using System.Xml;


namespace Sitecore.Foundation.MediaPlugin.Repositories
{
    public class MediaPluginConfiguration
    {
        public IMediaConfig GetMediaPluginConfiguration()
        {
            XmlNode node = Factory.GetConfigNode("mediaplugin");
            return Factory.CreateObject<IMediaConfig>(node);
        }
    }
}