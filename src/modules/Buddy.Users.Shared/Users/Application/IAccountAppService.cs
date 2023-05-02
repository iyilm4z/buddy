using System.Threading.Tasks;
using Buddy.Application;
using Buddy.Users.Application.Dto;

namespace Buddy.Users.Application;

public interface IAccountAppService : IApplicationService
{
    Task<LoginOutputDto> LoginAsync(LoginInputDto inputDto);
}