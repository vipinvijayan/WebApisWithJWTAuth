using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Models;
using DryCleanerAppDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DryCleanerAppDataAccess.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly DryCleanerContext _context;
        public CompanyRepository(DryCleanerContext dryCleanerContext)
        {
            _context = dryCleanerContext;
        }

        public async Task<string> CreateCompany(CompanyEntity param)
        {

            using (var db = _context)
            {
                await db.companyEntities.AddAsync(param);
                if (await db.SaveChangesAsync() > 0)
                {
                    return GeneralDTO.SuccessMessage;
                }
                else
                {
                    return GeneralDTO.FailedMessage;
                }
            }



        }
        public async Task<CompanyEntity?> GetCompanyById(int companyId)
        {
            var query = from company in _context.companyEntities
                        where company.Id == companyId
                        select company;
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<CompanyEntity>> GetAll(CommonSearchParam param)
        {
            var query = (from company in _context.companyEntities
                         where !company.IsDeleted && company.IsActive
                         select company);
            if (param.TakeAll)
            {
                return await query.ToListAsync();
            }
            else
            {
                return await query.Skip(param.SkipCount).Take(param.TakeCount).ToListAsync();
            }
        }
        public async Task<string?> GetUserFirstName(int userId)
        {

            return await _context.users.Where(e => e.Id == userId).Select(e => e.FirstName).SingleOrDefaultAsync();

        }
        public async Task<string> UpdateCompany(CompanyListModel company)
        {

            using (var db = _context)
            {
                CompanyEntity? companyEntity = await db.companyEntities.Where(e => e.Id == company.Id).FirstOrDefaultAsync();
                if (companyEntity != null)
                {
                    companyEntity.CompanyAddress = company.CompanyAddress;
                    companyEntity.CompanyCity = company.CompanyCity;
                    companyEntity.CompanyName = company.CompanyName;
                    companyEntity.CompanyPhone = company.CompanyPhone;
                    companyEntity.CompanyCountry = company.CompanyCountry;
                    companyEntity.CompanyState = company.CompanyState;
                    companyEntity.CompanyDescription = company.CompanyDescription;
                    companyEntity.CompanyEmail = company.CompanyEmail;
                    companyEntity.LandMark = company.LandMark;
                    companyEntity.Place = company.Place;

                    db.companyEntities.Update(companyEntity);
                    if (await db.SaveChangesAsync() > 0)
                    { return GeneralDTO.SuccessMessage; }
                    else { return GeneralDTO.FailedMessage; }
                }
                else { return GeneralDTO.NotExistMessage; }


            }
        }
        public async Task<string> DeleteCompanyById(int companyId)
        {

            using (var db = _context)
            {
                CompanyEntity? companyEntity = await db.companyEntities.Where(e => e.Id == companyId).FirstOrDefaultAsync();
                if (companyEntity != null)
                {
                    companyEntity.IsDeleted = true;

                    companyEntity.IsActive = false;
                    db.companyEntities.Update(companyEntity);
                    if (await db.SaveChangesAsync() > 0)
                    { return GeneralDTO.SuccessMessage; }
                    else { return GeneralDTO.FailedMessage; }
                }
                else { return GeneralDTO.NotExistMessage; }


            }
        }
    }
}
