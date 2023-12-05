using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.IRepository
{
    public interface IUserRepository
    {
        Task<UserEntity?> UserLogin(UserLoginParams param);
        Task<string> SaveLoginLog(LoginLogEntity param);
        Task<string> RegisterUser(UserEntity param);
    }
}
