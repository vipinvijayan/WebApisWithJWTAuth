using DryCleanerAppBussinessLogic.Implementation;
using DryCleanerAppBussinessLogic.Interfaces;
using DryCleanerAppDataAccess.Entities;

using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text.Json.Serialization;
using DM = DryCleanerAppDataAccess.Models;

namespace DryCleanerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserB _userB;
        private readonly IConfiguration _configuration;
        private readonly ISecurityB _securityB;
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(IUserB userB, ILogger<UserController> logger, IConfiguration configuration, ISecurityB securityB, IHttpClientFactory httpClientFactory)
        {
            _userB = userB;
            _logger = logger;
            _configuration = configuration;
            _securityB = securityB;
            _httpClientFactory = httpClientFactory;
        }
        // GET: UserController
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(DM::UserLoginParams param)
        {
            try
            {
                if (param != null)
                {
                    var companyId = _configuration.GetSection("AppSettings").GetValue<int>("CompanyId");

                    param.CompanyId = companyId;
                    DM.UserProfileModel? userProfileModel = await _userB.UserLogin(param);
                    if (userProfileModel != null)
                    {


                        string refreshToken = await _securityB.SaveRefreshToken(userProfileModel);

                        //   return RedirectToAction("CompanyList", "CompanyMaster");

                        return Json(refreshToken);

                    }
                    else
                    {
                        ViewBag.LoginMessage = "Login Failed";
                        return Json("Login Failed");
                    }

                }
                else
                {
                    ViewBag.LoginMessage = "Login Failed";
                    return Json("Login Failed");
                }
            }
            catch (ValidationException ex)
            {
                TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");
                return Json(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""));


            }
            catch (ArgumentException ar)
            {

                TempData["ErrorMessage"] = ar.Message + (ar.InnerException != null ? ar.InnerException.Message : "");
                return Json(ar.Message + (ar.InnerException != null ? ar.InnerException.Message : ""));
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");

                return Json(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""));
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> Index(UserLoginParams param)
        //{
        //    try
        //    {
        //        if (param != null)
        //        {
        //            var companyId = _configuration.GetSection("AppSettings").GetValue<int>("CompanyId");

        //            param.CompanyId = companyId;
        //            UserProfileModel? userProfileModel = await _userB.UserLogin(param);
        //            if (userProfileModel != null)
        //            {


        //                string refreshToken = await _securityB.SaveRefreshToken(userProfileModel);
        //                TempData["UserProfile"] = JsonConvert.SerializeObject(userProfileModel);

        //                TempData.Keep("UserProfile");
        //                Request.Headers.Authorization = new Microsoft.Extensions.Primitives.StringValues("Bearer " + refreshToken);

        //                return RedirectToAction("CompanyList", "CompanyMaster");

        //            }
        //            else
        //            {
        //                ViewBag.LoginMessage = "Login Failed";
        //                return View();
        //            }

        //        }
        //        else
        //        {
        //            ViewBag.LoginMessage = "Login Failed";
        //            return View();
        //        }
        //    }
        //    catch (ValidationException ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");
        //        return RedirectToAction("Index", "Error");


        //    }
        //    catch (ArgumentException ar)
        //    {

        //        TempData["ErrorMessage"] = ar.Message + (ar.InnerException != null ? ar.InnerException.Message : "");
        //        return RedirectToAction("Index", "Error");
        //    }
        //    catch (Exception ex)
        //    {

        //        TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");

        //        return RedirectToAction("Index", "Error");
        //    }

        //}


        // GET: UserController
        public ActionResult Registration()
        {
            return View();
        }
        //Register new User
        [HttpPost]
        public async Task<ActionResult> Registration(DM::UserRegistrationParam param)
        {
            try
            {
                var companyId = _configuration.GetSection("AppSettings").GetValue<int>("CompanyId");


                if (param != null)
                {
                    param.CompanyId = companyId;
                    string result = await _userB.UserRegistration(param);
                    if (result == DM.GeneralDTO.SuccessMessage)
                    {
                        DM.UserLoginParams loginParam = new DM.UserLoginParams();
                        loginParam.Username = param.Username;
                        loginParam.Password = param.Password;
                        loginParam.UserAgent = param.UserAgent;
                        loginParam.CompanyId = companyId;
                        DM.UserProfileModel? userProfileModel = await _userB.UserLogin(loginParam);
                        if (userProfileModel != null)
                        {

                            string refreshToken = await _securityB.SaveRefreshToken(userProfileModel);
                            TempData["UserProfile"] = userProfileModel;
                            TempData.Keep("UserProfile");
                            return RedirectToAction("CompanyList", "CompanyMaster");

                        }
                        else
                        {
                            ViewBag.LoginMessage = "Registration Failed";
                            return View();
                        }

                    }
                    else if (result == DM.GeneralDTO.AlreadyMessage)
                    {
                        ViewBag.LoginMessage = "User Already Registered ";
                        return View();
                    }
                }
                else
                {
                    ViewBag.LoginMessage = "Registration Failed";
                    return View();
                }
            }
            catch (ValidationException ex)
            {
                TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");
                return RedirectToAction("Index", "Error");


            }
            catch (ArgumentException ar)
            {

                TempData["ErrorMessage"] = ar.Message + (ar.InnerException != null ? ar.InnerException.Message : "");
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");

                return RedirectToAction("Index", "Error");
            }
            return View();
        }

    }
}
