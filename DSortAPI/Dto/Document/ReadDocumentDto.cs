using DSortAPI.Model;
using System.Text.Json.Serialization;

namespace DSortAPI.Dto.Document
    {
    public class ReadDocumentDto
        {        				
		public int Id { get; set; }

        public string DocTitle { get; set; }=string.Empty;
        
        public List<Scan> Scans { get; set; }=new List<Scan>();

        public List<Person> Persons { get; set; } = new List<Person>();
        public string Description { get; set; }=string.Empty;
        public string PhisicalAddress { get; set; }=string.Empty;

        }



    }
