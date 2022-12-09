using System.Security.Claims;
using Project_ITAcademy.Domain.Models;
using Project_ITAcademy.Domain.Response;
using Project_ITAcademy.Domain.ViewModels;

namespace Project_ITAcademy.Service.Interfaces;

public interface IUserService
{
    Task<BaseResponse<IEnumerable<User>>> GetUsers();
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterUserViewModel model);
    Task<BaseResponse<ClaimsIdentity>> Login(LoginUserViewModel model);
}