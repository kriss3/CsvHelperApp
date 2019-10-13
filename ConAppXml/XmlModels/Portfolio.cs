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
    public class Portfolio
    {
        [XmlAttribute]
        public int PortfolioId { get; set; }

        [XmlAttribute]
        public string PortfolioCode { get; set; }

        [XmlAttribute]
        public string PortfolioName { get; set; }

        [XmlAttribute]
        public int PortfolioValue { get; set; }
    }
}
