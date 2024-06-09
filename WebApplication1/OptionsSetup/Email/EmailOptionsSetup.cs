using Infrastructure;
using Microsoft.Extensions.Options;

namespace BookStore.OptionsSetup.Email;

public class EmailOptionsSetup(IConfiguration _configuration) : IConfigureOptions<EmailOptions>
{
    public readonly static string _key = "mail";
    public void Configure(EmailOptions options)
    {
        _configuration.GetSection(_key).Bind(options);
    }
}
