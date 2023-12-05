using DryCleanerAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic.Interfaces
{
    public interface ICompanyB
    {
        Task<string> CreateCompany(CompanyModel param);
        Task<List<CompanyListModel>> GetAll(CommonSearchParam param);
        Task<CompanyListModel> GetCompanyById(int companyId);
        Task<string> DeleteCompanyById(int companyId);
        Task<string> UpdateCompany(CompanyListModel company);
    }
}
