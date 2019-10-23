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
            //Run();
            RunWithNotes();
        }

        private static void RunWithNotes()
        {
            Helper hp = new Helper();
            var d = hp.GetXsdNote();

            var res = hp.MappToXsdNote(d);
            hp.DoXmlWork(res);
        }

        public static void Run() 
        {
            Helper hp = new Helper();
            hp.DoXmlWork(hp.GetData());
        }
    }
}
