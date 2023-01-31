using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSortAPI.Model
	{
	public class Document
		{		
		public int  Id { get; set; }
		
		public string DocTitle { get; set; } = string.Empty;	
		
		public List<Person> Persons { get; set; } = new List<Person>();
		public string ScanPath { get; set; } = string.Empty;
		public string Description { get; set; } =string.Empty;
		public string PhisicalAddress { get; set; } = string.Empty;

		}
	}
