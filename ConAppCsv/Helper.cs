using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using CsvHelper;
using System.Data.SqlClient;
using System.Data;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ConAppCsv
{
	public static class Helper
	{
		public static DateTime GetCurrentDate()
		{
			return DateTime.Now;
		}
		public static string GetFileFolder()
		{
			return ConfigurationManager.AppSettings["FILE_FOLDER"].ToString();
		}
		public static List<NetSuiteRecord> GetNSRecords(string location)
		{
			var result = new List<NetSuiteRecord>();
			var rec = new NetSuiteRecord();
	
			using (var tr = new StreamReader(location))
			{
				var csv = new CsvReader(tr);
				while (csv.Read())
				{
					var accId = csv.GetField<int>("AccountId");
					//var nsContractId = csv.GetField<int>("NSContractItemId");
					var po = csv.GetField<string>("PO");
					var prod = csv.GetField<string>("Product");
					var qty = csv.GetField<int>("Quantity");
					var term = csv.GetField<decimal>("Term");
					//var rel_tranId = csv.GetField<string>("related_tranid");

					result.Add(new NetSuiteRecord { AccountId = accId, PO = po, Product = prod, Quantity = qty, Term = term});
				}
			}
			return result;
		}

		public static List<NetSuiteRecord> GetNSRecordsFromOrp()
		{
			var results = new List<NetSuiteRecord>();
			var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

			using (var conn = new SqlConnection(connString))
			{
				var query = @"select ABS_AccountId, related_tranid, ProductCode, Quantity, ItemTerm from ns.NS_ContractItems nolock
							   where ABS_AccountId <> ''";
				using (var cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = query;
					cmd.Connection = conn;

					conn.Open();

					using (var dr = cmd.ExecuteReader())
					{
						string accountId, po, product, qty, term;

						while (dr.Read())
						{
							accountId = dr["ABS_AccountId"] as string;
							po = dr["related_tranid"] as string;
							product = dr["ProductCode"] as string;
							qty = dr["Quantity"] as string;
							term = dr["ItemTerm"] as string;

							results.Add(new NetSuiteRecord { AccountId = int.Parse(accountId), PO = po,
																Product = product, Quantity = int.Parse(qty), Term = int.Parse(term) });
						}
					}
				}
			}
			return results;
		}

		public static List<BSRecord> GetBSRecords()
		{
			var results = new List<BSRecord>();
			var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

			using (var conn = new SqlConnection(connString))
			{
				var query = @"Select account_id, po, quantity, product, term from dbo.BoughtServices nolock  
							where po is not null 
							  and len(account_id) > 0 
							  and Quantity is not null 
							  and Term is not null
							  and Expiry >= GETDATE()
							order by CreateDate desc";


				using (var cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = query;
					cmd.Connection = conn;

					conn.Open();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						int accountId, qty, term;
						string po, product;

						while (dr.Read())
						{
							accountId = (int)dr["account_id"];
							po = dr["PO"] as string;
							product = dr["Product"] as string;
							qty = (int)dr["Quantity"];
							term = (int)dr["Term"];

							results.Add(new BSRecord { AccountId = accountId, Po = po, Product = product, Qty = qty, Term = term });
						}
					}
				}

			}

			return results;
		}
		public static bool SaveListToFile(List<NetSuiteRecord> listToFile)
		{
			var location = @"c:/temp/results.csv";
			var result = false;
			using (TextWriter tw = new StreamWriter(location))
			{
				tw.WriteLine("AccountId,PO,Product,Quantity,Term");
				foreach (var item in listToFile)
				{
					tw.WriteLine(item.ToString());
				}
				result = true;
			}

			return result;
		}
	}
}
