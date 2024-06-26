﻿using System.IO;
using Microsoft.Extensions.Configuration;


namespace Auxiliar.Helper
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigurationManager() => AppSetting = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();
    }
}
