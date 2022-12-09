using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Project_ITAcademy.DAL.Interfaces;
using Project_ITAcademy.Domain.Enum;
using Project_ITAcademy.Domain.Helpers;
using Project_ITAcademy.Domain.Models;
using Project_ITAcademy.Domain.Response;
using Project_ITAcademy.Domain.ViewModels;
using Project_ITAcademy.Service.Interfaces;

namespace Project_ITAcademy.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<BaseResponse<IEnumerable<User>>> GetUsers()
    {
        var baseResponse = new BaseResponse<IEnumerable<User>>();
        try
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = users;
            baseResponse.StatusCode = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<User>>()
            {
                Description = $"[GetUsers] : {ex.Message}"
            };
        }
    }


    public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterUserViewModel model)
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            if (users.FirstOrDefault(x => x.Email == model.Email) != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким Email уже зарегистрирован"
                };
            }


            var user = new User()
            {
                FullName = model.Name,
                Email = model.Email,
                Password = HashPasswordHelper.HashPassword(model.Password)
            };

            await _userRepository.AddAsync(user);
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Пользователь зарегистрирован",
                StatusCode = StatusCode.Ok
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Register]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> Login(LoginUserViewModel model)
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (user.Password != HashPasswordHelper.HashPassword(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Неверный пароль"
                };
            }

            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.Ok
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Register]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.FullName),
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")
        };
        return new ClaimsIdentity(claims, "ApplicationCookie", 
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
}