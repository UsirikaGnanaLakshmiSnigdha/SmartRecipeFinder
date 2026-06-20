using Microsoft.AspNetCore.Mvc;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace SmartRecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _configuration;

        public AuthController(
    ApplicationDbContext context,
    IConfiguration configuration)
        {
            _context = context;

            _configuration =
                configuration;
        }
        [HttpPost("register")]
        public IActionResult Register(
            RegisterRequest request)
        {
            var existingUser =
                _context.Users
                .FirstOrDefault(
                    x => x.Email == request.Email);

            if (existingUser != null)
            {
                return BadRequest(
                    "Email already exists");
            }

            User user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok(
                "Registration Successful");
        }

        [HttpPost("login")]
        public IActionResult Login(
            LoginRequest request)
        {
            var user =
    _context.Users
    .FirstOrDefault(
        x =>
        x.Email ==
        request.Email);

            if (user == null)
            {
                return Unauthorized(
                    "Invalid Login");
            }

            bool validPassword =
                BCrypt.Net.BCrypt.Verify(
                    request.Password,
                    user.PasswordHash);

            if (!validPassword)
            {
                return Unauthorized(
                    "Invalid Login");
            }
            var claims =
new[]
{
    new Claim(
        ClaimTypes.Name,
        user.FullName),

    new Claim(
        ClaimTypes.Email,
        user.Email),

    new Claim(
        ClaimTypes.Role,
        user.Role)
};

            var key =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!));

            var creds =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token =
            new JwtSecurityToken(
                issuer:
                    _configuration["Jwt:Issuer"],

                audience:
                    _configuration["Jwt:Audience"],

                claims:
                    claims,

                expires:
                    DateTime.Now.AddHours(2),

                signingCredentials:
                    creds);

            var jwtToken =
                new JwtSecurityTokenHandler()
                .WriteToken(token);

            return Ok(new
            {
                Token = jwtToken,

                user.UserId,

                user.FullName,

                user.Email,

                user.Role
            });
        }
    }
}