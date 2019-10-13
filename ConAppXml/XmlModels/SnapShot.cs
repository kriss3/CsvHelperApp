using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace ConAppXml.XmlModels
{
    [Serializable]
    [XmlRoot("Snapshot")]
    public class SnapShot
    {
        [XmlAttribute]
        public string CurrentDate { get; set; } = DateTime.Now.ToShortDateString();
        [XmlArray("Instruments")]
        [XmlArrayItem("Instrument")]
        public List<Instrument> Instruments { get; set; }
        [XmlArray("Portfolios")]
        [XmlArrayItem("Portfolio")]
        public List<Portfolio> Portfolios { get; set; }
    }
}
