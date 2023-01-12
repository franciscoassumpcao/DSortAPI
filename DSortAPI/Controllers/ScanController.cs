using AutoMapper;
using DSortAPI.Dto;
using DSortAPI.Model;
using Microsoft.AspNetCore.Mvc;

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

		}
	}
