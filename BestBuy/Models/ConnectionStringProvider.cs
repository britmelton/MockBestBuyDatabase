﻿using Microsoft.Extensions.Configuration;


namespace BbDatabase
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
