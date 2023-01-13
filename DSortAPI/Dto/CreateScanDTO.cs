namespace DSortAPI.Dto
	{
	public class CreateScanDTO
		{
		public string NameScan { get; set; } = string.Empty;
		public string filePath { get; set; } = string.Empty;
		public int DocumentId { get; set; } = 1;

		}
	}
