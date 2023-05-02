using System.Threading.Tasks;
using Buddy.Domain.Repositories;
using Buddy.Users.Application.Dto;
using Buddy.Users.Configurations;
using Buddy.Users.Domain.Entities;
using Buddy.Users.Domain.Repositories;
using Buddy.Users.Domain.Services;

namespace Buddy.Users.Application;

public class AccountAppService : IAccountAppService
{
    private readonly IUserDomainService _userDomainService;
    private readonly IRepository<User> _userRepository;

    public AccountAppService(IUserDomainService userDomainService,
        IRepository<User> userRepository)
    {
        _userDomainService = userDomainService;
        _userRepository = userRepository;
    }

    public async Task<LoginOutputDto> LoginAsync(LoginInputDto inputDto)
    {
        var userLoginResult = await _userDomainService.CheckUserLoginAsync(inputDto.UsernameOrEmail, inputDto.Password);

        var outputDto = new LoginOutputDto(userLoginResult);

        if (userLoginResult != UserLoginResult.Successful)
        {
            return outputDto;
        }

        var user = UserSettings.UsernamesEnabled
            ? await _userRepository.GetByUsernameAsync(inputDto.UsernameOrEmail)
            : await _userRepository.GetByEmailAsync(inputDto.UsernameOrEmail);

        outputDto.LoggedInUser = new LoggedInUserDto(user.Id)
        {
            Email = user.Email,
            Username = user.Username
        };

        return outputDto;
    }
}