using Buddy.Users.Domain.Entities;

namespace Buddy.Users.Application.Dto;

public class LoggedInUserDto : IUser
{
    public int Id { get; }

    public string Username { get; set; }

    public string Email { get; set; }

    public LoggedInUserDto(int id)
    {
        Id = id;
    }
}