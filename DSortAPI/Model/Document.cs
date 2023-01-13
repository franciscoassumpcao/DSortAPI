using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSortAPI.Model
	{
	public class Document
		{		
		public int  Id { get; set; }
		
		public string? DocTitle { get; set; }
		public List<Scan> Scans { get; set; }
		public List<Person> Persons { get; set; }
		public string? Description { get; set; }
		public string? PhisicalAddress { get; set; }

		}
	}
