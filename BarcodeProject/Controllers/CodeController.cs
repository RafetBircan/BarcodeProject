using Microsoft.AspNetCore.Mvc;
using BarcodeProject.Aplication.Services;

namespace BarcodeProject.Controllers
{
    [ApiController]
    [Route("codes")]
    public class CodeController : ControllerBase
    {
        private readonly CodeService _codeService;
        public CodeController(CodeService codeService) => _codeService = codeService;

        // GET /codes
        [HttpGet]
        public async Task<IActionResult> GetAllCodes()
            => Ok(await _codeService.GetAllAsync());

        // GET /codes/{id}
        // Buraya Name ekliyoruz!
        [HttpGet("{id:int}", Name = "GetCodeById")]
        public async Task<IActionResult> GetCodeById(int id)
        {
            var code = await _codeService.GetByIdAsync(id);
            if (code == null)
                return NotFound($"Code with ID {id} not found.");
            return Ok(code);
        }

        // POST /codes
        [HttpPost]
        public async Task<IActionResult> CreateCode()
        {
            var code = await _codeService.GenerateNewCodeAsync();
            // Burada CreatedAtRoute kullanıyoruz:
            return CreatedAtRoute(
                routeName: "GetCodeById",         // ① yukarıdaki Name ile birebir aynı
                routeValues: new { id = code.Id },// ② id parametresini dolduruyor
                value: code                        // ③ response body olarak kodu gönderiyor
            );
        }

        // POST /codes/validate
        [HttpPost("validate")]
        public IActionResult ValidateCode([FromBody] string code)
            => Ok(new { code, isValid = _codeService.ValidateCode(code) });
    }
}
