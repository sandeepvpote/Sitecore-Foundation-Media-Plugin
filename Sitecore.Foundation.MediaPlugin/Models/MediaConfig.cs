using System.Collections.Generic;
using System.Xml;

namespace Sitecore.Foundation.MediaPlugin.Models
{
    public class MediaConfig : IMediaConfig
    {
        private readonly List<FileConfig> _fileConfig = new List<FileConfig>();

        public IEnumerable<FileConfig> FileConfig
        {
            get { return _fileConfig; }
        }

        protected void AddFileConfig(XmlNode node)
        {
            if (node?.Attributes?["extension"]?.Value == null)
                return;

            _fileConfig.Add(new FileConfig(){Extension = node.Attributes["extension"].Value, MediaType = node.Attributes["mediatype"].Value,
                                                SizeAllowed = System.Convert.ToInt32(node.Attributes["sizeallowed"].Value), SizeUnit = node.Attributes["sizeunit"].Value });
        }
    }

    public interface IMediaConfig
    {
        IEnumerable<FileConfig> FileConfig { get; }
    }

    public class FileConfig
    {
        public string Extension { get; set; }
        public int SizeAllowed { get; set; }
        public string SizeUnit { get; set; }
        public string MediaType { get; set; }
    }
}