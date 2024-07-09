using System.Diagnostics;
using Application.Services.Interfaces.IChatServices;
using Application.Services.Interfaces.IUserServices;
using Application.Utilities;
using Domain.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using E_Chat.Models;
using LabelPrintingEF.Application.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace E_Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IChatGroupService _chatGroupService;
        private readonly IUserGroupService _userGroupService;
        public HomeController(IChatGroupService chatGroupService, IUserGroupService userGroupService)
        {
            _chatGroupService = chatGroupService;
            _userGroupService = userGroupService;
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

        [HttpPost]
        public RequestResult JoinGroup(int groupId)
        {
            return _userGroupService.Add(new UserGroupDto()
            {
                UserId = User.GetUserId(),
                ChatGroupId = groupId
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}