using DryCleanerAppBussinessLogic.Interfaces;
using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Models;
using DryCleanerAppDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic.Implementation
{

    public class UserB : IUserB
    {
        readonly IUserRepository _userRepository;
        readonly ICompanyRepository _companyRepository;

        public UserB(IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public async Task<UserProfileModel?> UserLogin(UserLoginParams param)
        {
            UserProfileModel userProfileModel = null;
            UserEntity? userEntity = await _userRepository.UserLogin(param);
            LoginLogEntity loginLogEntity = new LoginLogEntity();
            loginLogEntity.UserName = param.Username;
            loginLogEntity.UserAgent = param.UserAgent;

            if (userEntity == null)
            {
                loginLogEntity.LoginStatus = "Failed";
            }
            else
            {
                loginLogEntity.LoginStatus = "Success";
                CompanyEntity companyEntity = await _companyRepository.GetCompanyById(param.CompanyId);
                loginLogEntity.Company = companyEntity;
                userProfileModel = new UserProfileModel();
                userProfileModel.Id = userEntity.Id;
                userProfileModel.CompanyId = param.CompanyId;
                userProfileModel.CompanyName = loginLogEntity.Company.CompanyName;
                userProfileModel.Username = userEntity.Username;
                userProfileModel.CreatedOn = userEntity.CreatedOn;
                userProfileModel.Email = userEntity.Email;
                userProfileModel.FirstName = userEntity.FirstName;
                userProfileModel.LastName = userEntity.LastName;
                userProfileModel.MobileNo = userEntity.MobileNo;
                loginLogEntity.UserData = userEntity;

            }
            await _userRepository.SaveLoginLog(loginLogEntity);
            return userProfileModel;

        }

        public async Task<string> UserRegistration(UserRegistrationParam param)
        {

            UserEntity? userEntity = new UserEntity();
            userEntity.Username = param.Username;
            userEntity.Password = param.Password;
            userEntity.Email = param.Email;
            userEntity.FirstName = param.FirstName;
            userEntity.LastName = param.LastName;
            userEntity.MobileNo = param.MobileNo;
            CompanyEntity companyEntity = await _companyRepository.GetCompanyById(param.CompanyId);
            userEntity.Company = companyEntity;
            return await _userRepository.RegisterUser(userEntity);


        }
    }
}
