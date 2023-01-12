using AutoMapper;
using DSortAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSortAPI.Controllers
	{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
		{
		private static List<Person> Persons;
		private readonly IMapper _mapper;
		private DataContext _context;


		public PersonController(IMapper mapper, DataContext context)
			{
			_mapper = mapper;
			_context = context;
			}

		[HttpPost]
		public async Task<ActionResult<List<Person>>> CreateNewPerson(string name)			
			{
			Person newPerson = new Person();
			newPerson.Name = name;

			_context.Persons.Add(newPerson);
			await _context.SaveChangesAsync();

			return Ok(await _context.Persons.ToListAsync());

			}

		[HttpGet]
		public async Task<ActionResult> Get()
			{
			if (_context.Persons.Any()) return Ok(await _context.Persons.ToListAsync());

			else return BadRequest("Persons not found");
			}






		}
	}
