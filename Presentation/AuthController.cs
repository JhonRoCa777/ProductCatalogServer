using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Model.CredentialModel;
using ProductCatalog.Domain.Model.EnumsModel;
using ProductCatalog.Infrastructure.Adapters.Entity;
using ProductCatalog.Infrastructure.Adapters.Utils;

namespace ProductCatalog.Presentation
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController(
        ProductCatalogDBContext context,
        EncrypUtil encrypt,
        JwtUtil jwt
    )
        : ControllerBase
    {
        private readonly ProductCatalogDBContext _context = context;
        private readonly EncrypUtil _encrypt = encrypt;
        private readonly JwtUtil _jwt = jwt;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CredentialRequestDTO credentialDTO)
        {
            var credential = new CredentialEntity
            {
                Email = credentialDTO.Email,
                Password = _encrypt.Encrypt(credentialDTO.Password),
                Role = RolesDTO.CLIENT
            };

            await _context.CredentialEntity.AddAsync(credential);
            await _context.SaveChangesAsync();

            if(credential.ID != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(CredentialRequestDTO credentialDTO)
        {
            var encryptedPassword = _encrypt.Encrypt(credentialDTO.Password);

            var credential = await _context.CredentialEntity
                .FirstOrDefaultAsync(x => x.Email == credentialDTO.Email && x.Password == encryptedPassword);

            if(credential == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _jwt.Generate(credential) });
        }
    }
}
