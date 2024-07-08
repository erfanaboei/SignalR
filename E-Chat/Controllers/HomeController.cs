using System.Diagnostics;
using Application.Services.Interfaces.IChatServices;
using Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using E_Chat.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IChatGroupService _chatGroupService;

        public HomeController(IChatGroupService chatGroupService)
        {
            _chatGroupService = chatGroupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RequestResult CreateGroup(string groupName)
        {
            return _chatGroupService.Add(groupName, User.GetUserId());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}