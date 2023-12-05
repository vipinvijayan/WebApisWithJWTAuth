using DryCleanerAppDataAccess.DataAccess;
using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        readonly DryCleanerContext _context;
        public SecurityRepository(DryCleanerContext dryCleanerContext)
        {
            _context = dryCleanerContext;
        }

        public async Task<string> SaveRefreshToken(RefreshTokenEntity param)
        {

            _context.refreshTokenEntities.Add(param);
            if (await _context.SaveChangesAsync() > 0)
            {
                return GeneralDTO.SuccessMessage;
            }
            else
            {
                return GeneralDTO.FailedMessage;
            }

        }
    }
}
