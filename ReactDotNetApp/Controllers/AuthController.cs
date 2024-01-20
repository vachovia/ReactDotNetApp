using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReactDotNetApp.DataAccess;
using ReactDotNetApp.DTO.AuthDto;
using ReactDotNetApp.Models;
using ReactDotNetApp.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReactDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IConfiguration configuration, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequestDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                
                var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (user == null || passwordValid == false)
                {
                    return Unauthorized(loginDto);
                }

                string tokenString = await GenerateToken(user);

                var response = new AuthResponse
                {
                    UserId = user.Id,
                    Token = tokenString,
                    Email = loginDto.Email
                };

                return response;
            }
            catch (Exception ex)
            { 
                return Problem($"Something Went Wrong in the {nameof(Login)}: {ex.Message}", statusCode: 500);
            }
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] securityKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);
            var issuerSigningKey = new SymmetricSecurityKey(securityKey);
            var credentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.Name, user.Name),
                new Claim(CustomClaimTypes.Uid, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            }.Union(userClaims)
             .Union(roleClaims);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:Duration"])),
                SigningCredentials = credentials,
                Audience = _configuration["JwtSettings:Audience"],
                Issuer = _configuration["JwtSettings:Issuer"]
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
            
        }

        //private async Task<string> GenerateToken(AppUser user)
        //{
        //    var securityKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);
        //    var issuerSigningKey = new SymmetricSecurityKey(securityKey);
        //    var credentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

        //    var roles = await _userManager.GetRolesAsync(user);

        //    var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

        //    // In case if we during the registration gave claims to user
        //    // we can retrieve it back into the JWT payload
        //    var userClaims = await _userManager.GetClaimsAsync(user);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Sub is subject and subject is User
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jti against Replay attacks
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim(CustomClaimTypes.Uid, user.Id)
        //    }
        //    .Union(userClaims)
        //    .Union(roleClaims);

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JwtSettings:Issuer"],
        //        audience: _configuration["JwtSettings:Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:Duration"])),
        //        signingCredentials: credentials
        //    );

        //    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwtToken;
        //}

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registerDto)
        {
            try
            {
                string email = registerDto.Email.ToLower();

                var userFromDb = _context.AppUsers.FirstOrDefault(u => u.UserName == email);

                if (userFromDb != null)
                {
                    return BadRequest("Username already exists.");
                }

                var user = _mapper.Map<AppUser>(registerDto);

                user.UserName = email;

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                if (!_roleManager.RoleExistsAsync(CustomClaimTypes.Role_User).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(CustomClaimTypes.Role_User));
                }

                if (!_roleManager.RoleExistsAsync(CustomClaimTypes.Role_Admin).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(CustomClaimTypes.Role_Admin));
                }

                if (registerDto.Role.ToLower() == CustomClaimTypes.Role_Admin)
                {
                    await _userManager.AddToRoleAsync(user, CustomClaimTypes.Role_Admin);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, CustomClaimTypes.Role_User);
                }                

                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something Went Wrong in the {nameof(Register)}: {ex.Message}", statusCode: 500);
            }
        }
    }
}
