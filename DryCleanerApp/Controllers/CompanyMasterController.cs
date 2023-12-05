using DryCleanerAppBussinessLogic.Interfaces;
using DryCleanerAppDataAccess.Models;
using EcomMVC.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DryCleanerApp.Controllers
{
    [Authorize]
    public class CompanyMasterController : Controller
    {
        readonly ICompanyB _companyB;
        private readonly ILogger<CompanyMasterController> _logger;

        public CompanyMasterController(ICompanyB companyB, ILogger<CompanyMasterController> logger)
        {
            _companyB = companyB;
            _logger = logger;
        }
        public IActionResult Index()
        {

            return View();
        }
        public ActionResult CreateCompany()
        {
            return View(new CompanyModel());
        }
        /// <summary>
        /// To create a new company
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateCompany(CompanyModel model)
        {

            _logger.LogDebug("Saving First Call");
            _companyB.CreateCompany(model);
            _logger.LogDebug("Saving Last Call");
            return View(model);
        }
        /// <summary>
        /// Get All Company list
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ActionResult> CompanyList(CommonSearchParam param)
        {

            _logger.LogDebug("Get Companies First Call");
            List<CompanyListModel> companyMasters = await _companyB.GetAll(param);
            _logger.LogDebug("Get Companies Last Call");
            return View(companyMasters);
        }
        /// <summary>
        /// To get company data for edit and update purpose
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int Id)
        {

            _logger.LogDebug("Get Companies First Call");
            CompanyListModel companyMasters = await _companyB.GetCompanyById(Id);
            _logger.LogDebug("Get Companies Last Call");
            return View(companyMasters);
        }
        /// <summary>
        /// Save changes after editing the company details
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(CompanyListModel parm)
        {

            _logger.LogDebug("Saving changes first call");
            string result = await _companyB.UpdateCompany(parm);
            if (result != GeneralDTO.SuccessMessage)
            {
                _logger.LogDebug("Error on saving changes");
                ViewBag.Message = "Error on saving changes";
                return View();
            }
            else
            {
                //After saving changes go to the company list page
                return RedirectToAction("CompanyList");
            }
        }

        /// <summary>
        /// To view the details of the specific company by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int Id)
        {
            _logger.LogDebug("Get Companies First Call");
            CompanyListModel companyMasters = await _companyB.GetCompanyById(Id);
            _logger.LogDebug("Get Companies Last Call");
            return View(companyMasters);
        }

        /// <summary>
        /// Get data from the company to delete purpose by company id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int Id)
        {
            _logger.LogDebug("Get Companies First Call");
            CompanyListModel companyMasters = await _companyB.GetCompanyById(Id);
            _logger.LogDebug("Get Companies Last Call");
            return View(companyMasters);
        }

        /// <summary>
        /// Deleting the company by company id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            _logger.LogDebug("Get Companies First Call");
            string result = await _companyB.DeleteCompanyById(Id);

            if (result != GeneralDTO.SuccessMessage)
            {
                _logger.LogDebug("Error on Deletion");
                return View();
            }
            else
            {
                _logger.LogDebug("Company Deleted");
                //After deleting go to the company list page
                return RedirectToAction("CompanyList");
            }
        }
    }
}
