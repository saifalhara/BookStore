﻿using Domain.Entity;
using Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.TokenServices;
public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenrateToken(User user)
    {
        var claims = new Claim[]
        {
             new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()) ,
                new Claim(JwtRegisteredClaimNames.Email , user.Email) ,
                new Claim("User_Id" , user.Id.ToString()),
                new Claim("UserName" , user.UserName)
        };

        var signingCredintials = new SigningCredentials(
          new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_options.SecretKey)),
          SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredintials
            );

        string tokenvalue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenvalue;
    }
}