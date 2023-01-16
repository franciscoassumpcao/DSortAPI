using AutoMapper;
using DSortAPI.Dto.Document;
using DSortAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSortAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DocumentController : ControllerBase
		{
		private IMapper _mapper;
		private DataContext _context;
		private readonly HttpClient httpClient;

		public DocumentController(IMapper mapper, DataContext context, HttpClient _httpClient)
			{
			_mapper = mapper;
			_context = context;
			this.httpClient = _httpClient;
			}

		[HttpGet("getAllDocuments")]
		public async Task<ActionResult<List<ReadDocumentDto>>> GET()
			{
			var documentsSearched = await _context.Documents
				.Include(d => d.Persons)
				.Include(d => d.Scans)
				.ToListAsync();

			if (documentsSearched == null) return null;


			List<ReadDocumentDto> documentsDto = new List<ReadDocumentDto>();
			foreach (var doc in documentsSearched)
				{
				ReadDocumentDto dto = new ReadDocumentDto();
				_mapper.Map(doc, dto);
				documentsDto.Add(dto);
				}


			return documentsDto;
			}

		[HttpGet("getDocumentWithId/{docId}")]
		public async Task<ActionResult<List<ReadDocumentDto>>> GetSingleDocument(int docId)
			{
			var documentSearched = await _context.Documents
				.Where(d => d.Id == docId)
				.Include(d => d.Persons)
				.Include(d => d.Scans)
				.ToListAsync();				

			if (documentSearched == null) return BadRequest("Document ID not found");

			ReadDocumentDto dto = new ReadDocumentDto();
			_mapper.Map(documentSearched, dto);

			return Ok(dto);

			}

		[HttpPost("createNewDocument")]
		public async Task<ActionResult<List<Document>>> CreateDocument(CreateDocumentDto dto)
			{
			Document documentToAdd = new Document();
			_mapper.Map(dto,documentToAdd);

            _context.Documents.Add(documentToAdd);

			_context.SaveChanges();

			return Ok("Document added");

			}

		[HttpPut("updateNewDocument")]
		public async Task<ActionResult<List<Document>>> UpdateDocument(Document newInfoDocument)
			{
			var documentSearched = await _context.Documents.FindAsync(newInfoDocument.Id);				

			if (documentSearched == null) return BadRequest("Document ID not found");

			
			_mapper.Map(newInfoDocument, documentSearched);
			await _context.SaveChangesAsync();			

			return Ok(await _context.Documents.ToListAsync());
			}


		[HttpDelete("deleteDocumentWithId/{docId}")]
		public async Task<ActionResult<List<Document>>> DeleteDocument(int docId)
			{
			var documentSearched = await _context.Documents.FindAsync(docId);

			if (documentSearched == null) return BadRequest("Document ID not found");

			
			_context.Documents.Remove(documentSearched);
			await _context.SaveChangesAsync();
				
			
			return Ok(await _context.Documents.ToListAsync());
			}



		}
	}
