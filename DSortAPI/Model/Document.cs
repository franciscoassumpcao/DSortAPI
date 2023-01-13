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


		//TODO
		// Add the other fields for Document, like description, address, filepath, and so on

		}
	}
