using AutoMapper;
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

		public DocumentController(IMapper mapper, DataContext context)
			{
			_mapper = mapper;
			_context = context;
			}

		[HttpGet]
		public async Task<ActionResult<List<Document>>> GetAllDocuments()
			{
			var documentsSearched = await _context.Documents								
				.ToListAsync();

			if (documentsSearched == null) return BadRequest("Documents not found");

			return Ok(documentsSearched);
			}

		[HttpGet("{docId}")]
		public async Task<ActionResult<List<Document>>> GetSingleDocument(int docId)
			{
			var documentSearched = await _context.Documents
				.Where(d => d.Id == docId)				
				.FirstOrDefaultAsync();				

			if (documentSearched == null) return BadRequest("Document ID not found");

			return Ok(documentSearched);

			}

		[HttpPost]
		public async Task<ActionResult<List<Document>>> CreateDocument(Document documentToAdd)
			{
			_context.Documents.Add(documentToAdd);

			await _context.SaveChangesAsync();

			return Ok(await _context.Documents.ToListAsync());

			}

		[HttpPut]
		public async Task<ActionResult<List<Document>>> UpdateDocument(Document newInfoDocument)
			{
			var documentSearched = await _context.Documents.FindAsync(newInfoDocument.Id);				

			if (documentSearched == null) return BadRequest("Document ID not found");

			
			_mapper.Map(newInfoDocument, documentSearched);
			await _context.SaveChangesAsync();			

			return Ok(await _context.Documents.ToListAsync());
			}


		[HttpDelete("{docId}")]
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
