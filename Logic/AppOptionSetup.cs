using Microsoft.Extensions.Options;

namespace ConfgApi.Logic;

public class AppOptionSetup : IConfigureOptions<AppOptions>
{
    private readonly IConfiguration _config;

    public AppOptionSetup(IConfiguration config)
    {
        _config = config;
    }

    public void Configure(AppOptions options)
    {
        _config.GetSection(nameof(AppOptions)).Bind(options);
    }
}
