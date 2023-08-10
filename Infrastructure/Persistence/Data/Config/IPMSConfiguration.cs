using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Data.Config
{
    public interface IPMSConfiguration
    {
        IConfigurationSection GetConfigurationSection(string Key);
    }
}
