using ConAppXml.XmlModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using static System.Console;

namespace ConAppXml
{
    internal class Helper
    {
        public Helper() { }

        public SnapShot GetData() 
        {
            var rs = new SnapShot();

            rs.Instruments = new List<Instrument>()
            {
                new Instrument{ InstrumentId=20, InstrumentName="MyInstrument01", InstrumentCategory="Category1", InstrumentValue=500 },
                new Instrument{ InstrumentId=20, InstrumentName="MyInstrument01", InstrumentCategory="Category1", InstrumentValue=500 },
                new Instrument{ InstrumentId=20, InstrumentName="MyInstrument01", InstrumentCategory="Category1", InstrumentValue=500 },
                new Instrument{ InstrumentId=20, InstrumentName="MyInstrument01", InstrumentCategory="Category1", InstrumentValue=500 },
                new Instrument{ InstrumentId=20, InstrumentName="MyInstrument01", InstrumentCategory="Category1", InstrumentValue=500 },
            };

            rs.Portfolios = new List<Portfolio>()
            {
                new Portfolio{ PortfolioId = 10, PortfolioCode="006", PortfolioName="PortTest01", PortfolioValue=100},
                new Portfolio{ PortfolioId = 10, PortfolioCode="006", PortfolioName="PortTest01", PortfolioValue=100},
                new Portfolio{ PortfolioId = 10, PortfolioCode="006", PortfolioName="PortTest01", PortfolioValue=100},
                new Portfolio{ PortfolioId = 10, PortfolioCode="006", PortfolioName="PortTest01", PortfolioValue=100},
                new Portfolio{ PortfolioId = 10, PortfolioCode="006", PortfolioName="PortTest01", PortfolioValue=100},
            };

            return rs;
        }


        public void DoXmlWork(SnapShot sp) 
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SnapShot.xml"))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SnapShot));
                    xmlSerializer.Serialize(sw, sp);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Something went wrong with serialization: {ex.Message}");
            }
        }
    }
}