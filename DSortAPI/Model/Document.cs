using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSortAPI.Model
	{
	public class Document
		{

		[Key]		
		public int  Id { get; set; }
		
		public string? DocTitle { get; set; }
		
		public string PhisicalAddress { get; set; } = string.Empty;
		public string? ShortDocDescription { get; set; }
		
		[Required]
		public int PersonId { get; set; }

		public string? ScanFileAddress { get; set; }
		public string? DocCategory { get; set; }






		}
	}
