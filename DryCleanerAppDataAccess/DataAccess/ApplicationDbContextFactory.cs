using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.DataAccess
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DryCleanerContext>
    {
        public DryCleanerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DryCleanerContext>();
            optionsBuilder.UseMySql("server=139.59.77.244;port=3306;user=vipin;password=itFirm@2015mysql;database=DryCleanerDB", ServerVersion.AutoDetect("server=139.59.77.244;port=3306;user=vipin;password=itFirm@2015mysql;database=DryCleanerDB"));

            return new DryCleanerContext(optionsBuilder.Options);
        }
    }
}
