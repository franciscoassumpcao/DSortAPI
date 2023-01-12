using DSortAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DSortAPI.Controllers
	{
	public class ScanController : Controller
		{
		public DataContext _context { get; }
		public ScanController(DataContext context)
			{
			_context = context;
			}

		[HttpGet]
		public async Task<ActionResult<List<Scan>>> Get(int DocumentId)
			{
			var scans = await _context.Scans
				.Where(s => s.DocumentId == DocumentId)
				.ToListAsync();

			return scans;


			}

		}
	}
