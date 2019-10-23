using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace ConAppXml.XmlModels
{
    [Serializable]
    [XmlRoot("Notes")]
    public class Note
    {
        [XmlElement]
        public string to { get; set; }
        [XmlElement]
        public string from { get; set; }
        [XmlElement]
        public string heading { get; set; }
        [XmlElement]
        public string body { get; set; }
    }
}
