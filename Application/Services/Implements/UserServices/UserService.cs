using System;
using System.Threading.Tasks;
using Application.Services.Interfaces.IUserServices;
using Application.Utilities;
using Domain.DTOs.AccountDTOs;
using Domain.Interfaces.IUserRepositories;
using Domain.Models.Users;
using LabelPrintingEF.Application.Helpers;
using Newtonsoft.Json;

namespace Application.Services.Implements.UserServices
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsExistUsername(string username)
        {
            return await _userRepository.IsExistUsername(username);
        }

        public async Task<bool> IsExistPhone(string phone)
        {
            return await _userRepository.IsExistPhone(phone);
        }

        public async Task<RequestResult> RegisterUser(RegisterDto dto)
        {
            if (await IsExistUsername(dto.Username))
            {
                return new RequestResult(false, RequestResultStatusCode.Conflict, "نام کاربری وارد شده تکراری است!", "Username");
            }

            if (await IsExistPhone(dto.Phone))
            {
                return new RequestResult(false, RequestResultStatusCode.Conflict, "شماره موبایل وارد شده تکراری است!", "Phone");
            }

            var model = new User()
            {
                Username = dto.Username,
                Phone = dto.Phone,
                Password = dto.Password,
                CreateDate = DateTime.Now,
                Avatar = "Default.jpg"
            };

            _userRepository.Add(model);
            return new RequestResult(true, RequestResultStatusCode.Success);
        }

        public async Task<RequestResult> LoginUser(LoginDto dto)
        {
            var user = await _userRepository.LoginUserByUsernameAndPassword(dto.Username, dto.Password);
            return user != null
                ? new RequestResult(true, RequestResultStatusCode.Success, data:JsonConvert.SerializeObject(user))
                : new RequestResult(false, RequestResultStatusCode.NotFound, "کاربری با این مشخصات یافت نشد!", "Username");
        }
    }
}