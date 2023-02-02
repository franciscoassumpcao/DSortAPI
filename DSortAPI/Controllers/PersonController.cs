using AutoMapper;
using DSortAPI.Dto.Document;
using DSortAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSortAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
		{
		private readonly IMapper _mapper;
		private DataContext _context;


		public PersonController(IMapper mapper, DataContext context)
			{
			_mapper = mapper;
			_context = context;
			}

		[HttpPost("createNewPersonJson")]
		public async Task<ActionResult<List<Person>>> CreateNewPerson(Person person)			
			{			
			_context.Persons.Add(person);
			await _context.SaveChangesAsync();

			return Ok(await _context.Persons.ToListAsync());
			}

        [HttpPost("postNewPersonWithName/{newPersonName}")]
        public async Task<ActionResult<List<Person>>> CreateNewPerson(string newPersonName)
            {
			Person personToAdd = new Person();
			personToAdd.Name = newPersonName;
            _context.Persons.Add(personToAdd);
            await _context.SaveChangesAsync();

            return Ok(await _context.Persons.ToListAsync());
            }

        [HttpPost("personDocument")]
		public async Task<ActionResult<Person>> AddDocumentPerson(AddDocumentPersonDto request)
			{
			var document = await _context.Documents
				.Where(d => d.Id == request.DocumentId)
				.Include(d => d.Persons)
				.FirstOrDefaultAsync();

			if (document == null) { return NotFound("Document not found"); }

			var person = await _context.Persons.FindAsync(request.PersonId);
			if (person == null) { return NotFound("Person not found"); }

			document.Persons.Add(person);

			await _context.SaveChangesAsync();

			return person;
			}

		[HttpGet("getPersonWithId/{personId}")]
		public async Task<ActionResult<List<Person>>> GetPersonId(int personId)
			{
			var personSearched = await _context.Persons
				.Where(p => p.Id == personId)
				.Include(p => p.Documents)
				.ToListAsync();

			if (personSearched==null) return BadRequest("Persons not found");

			return Ok(personSearched);
			}

		[HttpGet("getAllPerson")]
		public async Task<ActionResult<List<Person>>> GetAll()
			{
			if (_context.Persons.Any())
				{
				return Ok(await _context.Persons
					.Include(p => p.Documents)
					.ToListAsync());
				}

			else return BadRequest("Persons not found");
			}

		[HttpDelete("deletePersonWithId/{PersonId}")]
		public async Task<ActionResult<List<Person>>> DeletePerson(int PersonId)
			{
			if (await _context.Persons.FindAsync(PersonId)== null){
				return BadRequest("Person to remove not found");
				}

			_context.Persons.Remove(_context.Persons.FirstOrDefault(p=>p.Id==PersonId));
			await _context.SaveChangesAsync();
			return Ok();
			}

		[HttpPut("UpdateNewPerson")]
		public async Task<ActionResult<List<Person>>> UpdatePersonInfo(Person personToUpdate)
			{
			var personSearched = await _context.Persons.FindAsync(personToUpdate.Id);

			if (personSearched == null) return BadRequest("Person ID not found");

			_mapper.Map(personToUpdate, personSearched);
			
			await _context.SaveChangesAsync();

			return Ok(await _context.Persons.ToListAsync());

			}
		}
	}
