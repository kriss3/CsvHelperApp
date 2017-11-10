using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppCsv
{
	public class NetSuiteRecord
	{
		public int AccountId { get; set; }
		//public int NSContractItemId { get; set; }
		public string PO { get; set; }
		public string Product { get; set; }
		public int Quantity { get; set; }
		public decimal Term { get; set; }
		//public string tranid { get; set; }
		//public int related_tranid { get; set; }

		public override string ToString()
		{
			return String.Format($"{AccountId},{PO},{Product},{Quantity},{Term}");
		}
	}
}
