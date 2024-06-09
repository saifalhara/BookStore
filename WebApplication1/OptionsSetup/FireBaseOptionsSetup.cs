using Infrastructure;
using Microsoft.Extensions.Options;

namespace BookStore.OptionsSetup;

public class FireBaseOptionsSetup(IConfiguration _configuration) : IConfigureOptions<FireBaseOptions>
{
    public readonly string _key = "firebase";
    public void Configure(FireBaseOptions options)
    {
        _configuration.GetSection(_key).Bind(options);
    }
}
