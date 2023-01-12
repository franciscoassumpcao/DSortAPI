namespace DSortAPI.Model
	{
	public class Scan
		{

		public int Id { get; set; }
		public string NomeScan { get; set; }=string.Empty;
		public string filePath { get; set; } = string.Empty;
		public Document Document { get; set; }
		public int DocumentId { get; set; }

		}
	}
