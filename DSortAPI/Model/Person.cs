using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSortAPI.Model
	{
	public class Person
		{		
		public int Id { get; set; }
		
		public string Name { get; set; } = string.Empty;
		[JsonIgnore]
		public List<Document>? Documents { get; set; }

		}
	}