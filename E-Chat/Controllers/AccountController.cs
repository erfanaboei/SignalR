using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Services.Interfaces.IUserServices;
using Domain.DTOs.AccountDTOs;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Chat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await _userService.LoginUser(dto);

            if (result.IsSuccess)
            {
                var user = JsonConvert.DeserializeObject<User>(result.Data);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal);
                
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(result.Data)) return View(dto);

            ModelState.AddModelError(result.Data, result.Message);
            return View(dto);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await _userService.RegisterUser(dto);

            if (result.IsSuccess) return RedirectToAction("Login");

            if (string.IsNullOrEmpty(result.Data)) return View(dto);

            ModelState.AddModelError(result.Data, result.Message);
            return View(dto);
        }
    }
}