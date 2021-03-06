﻿using System;
using System.Collections.Generic;
using System.Text;
using Dare.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dare.Model.DBContext
{
    public class DareDBContext : DbContext
    {
        public IConfiguration _configuration { get; }
        public DareDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return _configuration["ConnectionString:DareDB"];
        }

        public DbSet<Owner> Owners { get; set; }
    }


}
