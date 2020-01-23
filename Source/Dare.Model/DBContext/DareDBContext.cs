using System;
using System.Collections.Generic;
using System.Text;
using Dare.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dare.Model.DBContext
{
    public class DareDBContext : DbContext
    {
        public DareDBContext(DbContextOptions<DareDBContext> options)
            : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
    }


}
