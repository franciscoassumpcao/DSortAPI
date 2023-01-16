using DSortAPI.Model;
using System.Text.Json.Serialization;

namespace DSortAPI.Dto.Document
{
    public class CreateDocumentDto
    {
        public string DocTitle { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string? PhisicalAddress { get; set; }

    }
}
