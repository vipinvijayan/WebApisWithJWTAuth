using DryCleanerAppDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.DataAccess
{
    public class DryCleanerContext : DbContext
    {
        public DryCleanerContext(DbContextOptions<DryCleanerContext> options) : base(options) { }
        public DbSet<CompanyEntity> companyEntities { get; set; }
        public DbSet<UserEntity> users { get; set; }
        public DbSet<UserAddressEntity> usersAddress { get; set; }
        public DbSet<LoginLogEntity> loginLog { get; set; }
        public DbSet<RefreshTokenEntity> refreshTokenEntities { get; set; }
    }
}
