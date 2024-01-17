using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using my_portfolio.Models;

namespace my_portfolio.Data
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<my_portfolio.Models.Project> Project { get; set; } = default!;
    }
}
