using AutoMapper;
using DSortAPI.Dto;
using DSortAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace DSortAPI.Controllers
	{
	[Route("api/[controller]")]
	[ApiController]
	public class ScanController : ControllerBase
		{
		public DataContext _context { get; set; }
		private IMapper _mapper;		

		public ScanController(DataContext context, IMapper mapper)
			{
			_context = context;
			_mapper = mapper;			
			}

		[HttpGet]
		public async Task<ActionResult<List<Scan>>> Get(int DocumentId)
			{
			var scans = await _context.Scans
				.Where(s => s.DocumentId == DocumentId)
				.ToListAsync();

			return scans;
			}



		[HttpPost]
		public async Task<ActionResult<List<Scan>>> Create(CreateScanDTO request)
			{
			var document = await _context.Documents.FindAsync(request.DocumentId);
			if (document == null) { return BadRequest("document not found"); }

			var newScan = new Scan();
			_mapper.Map(request, newScan);
			newScan.Document = document;

			_context.Scans.Add(newScan);
			await _context.SaveChangesAsync();
			return await Get(newScan.DocumentId);
			}

		[HttpDelete("{scanId}")]
		public async Task<ActionResult<Scan>> Delete(int scanId)
			{
			if (_context.Scans.Find(scanId) == null)
				{
				return BadRequest("Scan Id not found");
				}

			else {
				_context.Scans.Remove(_context.Scans.Find(scanId));
				await _context.SaveChangesAsync();				
				}

			return Ok("Scan deleted successfully");
			}


		[HttpPut]
		public async Task<ActionResult<Scan>> UpdateScan(Scan newScan)
			{
			var scanSearched = await _context.Scans.FindAsync(newScan.Id);

			if (scanSearched == null) return BadRequest("Scan ID not found");


			_mapper.Map(newScan, scanSearched);
			await _context.SaveChangesAsync();

			return Ok(await _context.Scans.ToListAsync());
			}

		[HttpPost("{ScanId}")]
		public async Task<ActionResult<Scan>> AddAttachmentToScan(int ScanId, byte[] attch)
			{
			var scan = await _context.Scans
				.FindAsync(ScanId);

			if (scan == null) return BadRequest("Scan Id not found");

			scan.Attachment = attch;
			_context.SaveChanges();

			return Ok("Attachment added to Scan");
			}

		[HttpGet("ScanId")]
		public byte[] DownloadFile(int ScanId)
			{
			byte[] attchment = _context.Scans.Find(ScanId).Attachment;

			if (attchment == null) return null;

			return attchment;
			}



		}
	}
