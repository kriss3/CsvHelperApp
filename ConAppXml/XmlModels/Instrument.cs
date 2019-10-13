using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConAppXml.XmlModels
{
    [Serializable]
    public class Instrument
    {
        [XmlAttribute]
        public int InstrumentId { get; set; }
        
        [XmlAttribute]
        public string InstrumentName { get; set; }
        
        [XmlAttribute]
        public int InstrumentValue { get; set; }
        
        [XmlAttribute]
        public string InstrumentCategory { get; set; }
    }
}
