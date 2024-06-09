using Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace BookStore.OptionsSetup.Jwt
{
    public class JwtOptionSetup(IConfiguration _configuration) : IConfigureOptions<JwtOptions>
    {
        private readonly string _JwtKey = "jwt";
        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(_JwtKey).Bind(options);
        }
    }
}
