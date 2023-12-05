using DryCleanerAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic.Interfaces
{
    public interface ISecurityB
    {
        string GenerateJWTToken(string userName, int userId);
        Task<string> SaveRefreshToken(UserProfileModel param);
    }
}
