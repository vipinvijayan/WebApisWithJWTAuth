using DryCleanerAppDataAccess.DataAccess;
using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DryCleanerContext _context;
        public UserRepository(DryCleanerContext dryCleanerContext)
        {
            _context = dryCleanerContext;
        }

        public async Task<UserEntity?> UserLogin(UserLoginParams param)
        {


            var query = from user in _context.users
                        where user.Username == param.Username && user.Password == param.Password && !user.IsDeleted
                          && user.IsActive
                        select user;

            return await query.FirstOrDefaultAsync();

        }

        public async Task<string> SaveLoginLog(LoginLogEntity param)
        {

            _context.loginLog.Add(param);
            if (await _context.SaveChangesAsync() > 0)
            {
                return GeneralDTO.SuccessMessage;
            }
            else
            {
                return GeneralDTO.FailedMessage;
            }
        }

        public async Task<string> RegisterUser(UserEntity param)
        {

            var query = from user in _context.users
                        where user.Username == param.Username && user.FirstName == param.FirstName
                        && user.LastName == param.LastName && user.MobileNo == param.MobileNo && user.Email == param.Email
                         && !user.IsDeleted && user.IsActive
                        select user;

            var userData = await query.FirstOrDefaultAsync();
            if (userData != null)
            {
                return GeneralDTO.AlreadyMessage;
            }
            else
            {

                _context.users.Add(param);
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
}
