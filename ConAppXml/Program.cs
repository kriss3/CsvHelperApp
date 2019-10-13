using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run() 
        {
            Helper hp = new Helper();
            hp.DoXmlWork(hp.GetData());
        }
    }
}
