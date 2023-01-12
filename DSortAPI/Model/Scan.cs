using System.Text.Json.Serialization;

namespace DSortAPI.Model
	{
	public class Scan
		{

		public int Id { get; set; }
		public string NameScan { get; set; }=string.Empty;
		public string filePath { get; set; } = string.Empty;
		[JsonIgnore]
		public Document Document { get; set; }
		public int DocumentId { get; set; }

		}
	}
