using DSortAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSortAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
        {
        private readonly IStorageService _storageService;

        public FileUploadController(IStorageService storageService)
            {
            _storageService = storageService;
            }


        [HttpGet]
        public IActionResult Get()
            {
            return Ok("File upload API running...");
            }


        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file)
            {
            _storageService.Upload(file);            

            return Ok();

            }
        }
    }
