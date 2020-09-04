using MAB.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace MAB.WebAPI.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
