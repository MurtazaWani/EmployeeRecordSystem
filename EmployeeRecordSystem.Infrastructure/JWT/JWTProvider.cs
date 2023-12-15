using EmployeeRecordSystem.Application.Abstraction.IJWT;
using EmployeeRecordSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeRecordSystem.Infrastructure.JWT;

public class JWTProvider : IJWTProvider
{
    //private const string UserRole = nameof(UserRole);
    private readonly IConfiguration config;
    public JWTProvider(IConfiguration config)
    {
        this.config = config;
    }
    public string GenerateToken(User user)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim("Email", user.Email),
            }),

            Expires = DateTime.Now.AddHours(1),
            Issuer = config["jwt:Issuer"],
            Audience = config["jwt:Audience"],

            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:Key"]!)), 
            SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }
}
