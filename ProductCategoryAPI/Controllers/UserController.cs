using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.LoginDto;
using DtoLayer.DTOs.RegisterDto;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryAPI.Models;

namespace ProductCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        protected readonly IConfiguration _configuration;

        public UserController(IUserService userService, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;   
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //önceden aynı mail kaydı var mı kontrol yap.
            var existingUser = _userService.TGetList().FirstOrDefault(x => x.UserName == registerDto.Mail);
            if (existingUser != null )
            {
                return BadRequest("Bu e-posta ile kayıtlı bir kullanıcı zaten mevcut.");
            }

            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerDto.Password);
                return Ok("Kayıt Başarılı");
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _userService.TGetList().FirstOrDefault(x => x.UserName == loginDto.UserName);
            if (user != null)
            {
                if (user.RealPassword == loginDto.Password)
                {
                    var tokenGenerator = new  Token(_configuration);
                    var token = tokenGenerator.TokenCreate();
                    return Ok("Giriş Başarılı \n Token: "+ token);

                }
                return BadRequest("Geçersiz şifre.");
            }
            return BadRequest("Geçersiz Mail");

        }

    }
}
