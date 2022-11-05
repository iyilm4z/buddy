using System;
using System.Threading.Tasks;
using Buddy.Domain.Repositories;
using Buddy.Runtime.Security;
using Buddy.Users.Configurations;
using Buddy.Users.Domain.Entities;
using Buddy.Users.Domain.Repositories;

namespace Buddy.Users.Domain.Services;

public class UserRegistrationDomainService : IUserRegistrationDomainService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<UserPassword> _userPasswordRepository;

    public UserRegistrationDomainService(IRepository<User> userRepository,
        IRepository<UserPassword> userPasswordRepository)
    {
        _userRepository = userRepository;
        _userPasswordRepository = userPasswordRepository;
    }

    protected virtual bool PasswordsMatch(UserPassword userPassword, string enteredPassword)
    {
        if (userPassword == null || string.IsNullOrEmpty(enteredPassword))
        {
            return false;
        }

        var savedPassword = userPassword.PasswordFormat switch
        {
            PasswordFormat.Clear => enteredPassword,
            PasswordFormat.Encrypted => EncryptionHelper.EncryptText(enteredPassword),
            PasswordFormat.Hashed => EncryptionHelper.CreatePasswordHash(enteredPassword, userPassword.PasswordSalt,
                UserSettings.HashedPasswordFormat),
            _ => string.Empty
        };

        return userPassword.Password != null
               && userPassword.Password.Equals(savedPassword);
    }

    public async Task<UserLoginResult> ValidateUserAsync(string usernameOrEmail, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(usernameOrEmail);

        if (user == null)
        {
            return UserLoginResult.NotExist;
        }

        if (user.Deleted)
        {
            return UserLoginResult.Deleted;
        }

        if (!user.Active)
        {
            return UserLoginResult.NotActive;
        }

        //check whether a customer is locked out
        if (user.CannotLoginUntilDateUtc.HasValue && user.CannotLoginUntilDateUtc.Value > DateTime.UtcNow)
        {
            return UserLoginResult.LockedOut;
        }

        if (!PasswordsMatch(await _userPasswordRepository.GetCurrentPasswordAsync(user.Id), password))
        {
            //wrong password
            user.FailedLoginAttempts++;
            if (UserSettings.FailedPasswordAllowedAttempts > 0 &&
                user.FailedLoginAttempts >= UserSettings.FailedPasswordAllowedAttempts)
            {
                //lock out
                user.CannotLoginUntilDateUtc = DateTime.UtcNow.AddMinutes(UserSettings.FailedPasswordLockoutMinutes);
                //reset the counter
                user.FailedLoginAttempts = 0;
            }

            await _userRepository.UpdateAsync(user);

            return UserLoginResult.WrongPassword;
        }

        //update login details
        user.FailedLoginAttempts = 0;
        user.CannotLoginUntilDateUtc = null;
        user.RequireReLogin = false;
        user.LastLoginDateUtc = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);

        return UserLoginResult.Successful;
    }
}