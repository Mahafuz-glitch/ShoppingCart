using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Dto;
using shoppingCartWebApi.Helper;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;
using System;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;



        public AuthenticationController(IUserRepository repository, JwtService jwtService)
        {
            _userRepository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto dto)
        {
            try
            {
                var user = new User
                {
                    FullName = dto.FullName,
                    EmailId = dto.EmailId,
                    MobileNumber = dto.MobileNumber,
                    DateOfBirth = dto.DateOfBirth,
                    Gender = dto.Gender,
                    ProfileRole = dto.ProfileRole,
                    ProfilePassword = BCrypt.Net.BCrypt.HashPassword(dto.ProfilePassword)
                };
                var newUser = _userRepository.Create(user);
                return Created("Sucess", newUser);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                var user = _userRepository.GetByEmail(dto.EmailId);
                if (user == null)
                    return BadRequest(new { message = "Invalid Email" });
                if (!BCrypt.Net.BCrypt.Verify(dto.ProfilePassword, user.ProfilePassword))
                {
                    return BadRequest(new { message = "Invalid Password" });
                }
                var jwtstring = _jwtService.Generate(user.ProfileId);
                Response.Cookies.Append("jwt", jwtstring, new CookieOptions
                {
                    HttpOnly = true,
                });
                return Ok(new
                {
                    message = "Success"
                });
            }
            catch (System.Exception)
            {
                 return BadRequest();
            }
        }
        [HttpGet("User")]
        public IActionResult Users()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetById(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpGet("UserAll")]
        public IActionResult UserAll()
        {
            var user = _userRepository.GetAll();
            return new OkObjectResult(user);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("jwt");
                return Ok(new
                {
                    message = "sucess"
                });
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
