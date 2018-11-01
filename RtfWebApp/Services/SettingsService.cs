using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IConfigurationSection _section;

        public SettingsService(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _section = configuration.GetSection("Settings") ?? throw new InvalidOperationException("Section Settings not found");
        }

        public double HRDefaultRate => _section.GetValue<double>($"{nameof(HRDefaultRate)}");
    }
}
