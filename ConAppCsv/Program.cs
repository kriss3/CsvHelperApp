using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using static System.Console;


namespace ConAppCsv
{
	class Program
	{
		static void Main(string[] args)
		{
			Run();
		}

		public static void Run()
		{
			Helper.GetCurrentDate();

			var fileFolder = Helper.GetFileFolder();
			var location = fileFolder + "BS_vs_ContractItems_altAproach_ActiveOnly.csv";

			var nsRecordsOrp = Helper.GetNSRecordsFromOrp();

			//var nsRecords = Helper.GetNSRecords(location);
			var bsRecords = Helper.GetBSRecords().ToLookup(x => new { acc = x.AccountId, po = x.Po, prod = x.Product, q = x.Qty });

			var bsRecordsAccPo = Helper.GetBSRecords().ToLookup(x=>new { acc = x.AccountId, po = x.Po, prod = x.Product});

			var bsRecordsOnly = Helper.GetBSRecords();

			//var result = bsRecords.Where(p1 => nsRecords.All(p2 => p2.AccountId == p1.AccountId)).Count();

			int myC = 0;


			//var query = (bsRecords.Where(ls1 => nsRecords.Any(ls2 => ls2.AccountId == ls1.AccountId && ls2.PO.Equals(ls1.Po)))).Count();
			//var q = bsRecords.Where(o => nsRecords.Any(w => w.AccountId == o.AccountId && w.PO == o.Po)).ToList();

			//var q = bsRecords.Where(a => nsRecords.Any(b => b.AccountId == a.AccountId && b.PO.Equals(a.Po))).ToList();


			//var q = (from a in bsRecords
			//		from b in nsRecords.Where(b => b.AccountId == a.AccountId && b.PO.Equals(a.Po))
			//		select a).ToList();

			//var m = nsRecords.Where(x => bsRecords.Contains(new { acc = x.AccountId, po = x.PO, prod = x.Product})).ToList().Take(100);


			//var k = nsRecords.Where(x=>!(bsRecords.Contains(new { acc=x.AccountId, po = x.PO, prod = x.Product, q = x.Quantity}))).ToList();

			//var l = nsRecords.Where(x => !(bsRecords.Contains(new { acc = x.AccountId, po = x.PO, prod = x.Product, q = x.Quantity }))).ToList();

			var m = nsRecordsOrp.Where(x => (bsRecordsAccPo.Contains(new { acc = x.AccountId, po = x.PO, prod = x.Product })) 
										  || bsRecordsAccPo.Contains(new { acc = x.AccountId, po = x.PO, prod = x.Product+"GF"})).Count();

			var counterAccPo = 0;
			var counterAccPoTerm = 0;


			foreach (var ns in nsRecordsOrp)
			{
				if (bsRecordsOnly.Where(x => x.AccountId == ns.AccountId && x.Po == ns.PO).Count() == 1)
				{
					counterAccPo++;
				}
				else if (bsRecordsOnly.Where(x => x.AccountId == ns.AccountId && x.Po == ns.PO && x.Term == ns.Term).Count() == 1)
				{
					counterAccPoTerm++;
				}
			
			}

			WriteLine($"Found Match on Account and PO: {counterAccPo} \nFound Match on Account, Po and Term: {counterAccPoTerm}");

			//var res = Helper.SaveListToFile(l);

			WriteLine(location);
			ReadLine();
		}
	}
}
