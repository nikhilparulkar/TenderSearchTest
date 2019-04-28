using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TenderSearchTest.DBAccess
{
    

        static class ConfigReader
        {
            public static IConfigurationRoot Configuration;

            public static string GetConnectionString()
            {
                var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
                var connectionString = Configuration["ConnectionStrings:MyConnectionString"];

            return connectionString;

            }

        }
    
}
