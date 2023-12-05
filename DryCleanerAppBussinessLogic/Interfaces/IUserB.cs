using DryCleanerAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic.Interfaces
{
    public interface IUserB
    {
        Task<UserProfileModel?> UserLogin(UserLoginParams param);
        Task<string> UserRegistration(UserRegistrationParam param);
    }
}
