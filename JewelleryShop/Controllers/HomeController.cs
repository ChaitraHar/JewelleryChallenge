using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JewelleryShop.Models;
using JewelleryShop.Helpers;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JewelleryShop.Controllers
{
    public class HomeController : Controller
    {
        #region private variables
        
        private readonly IHomeHelper _homehelper;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository repository;
        private static string folderPath = "C:\\JewelleryEstimate\\";
        private static string filePath = folderPath + "Estimate.txt";

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="homehelper"></param>
        /// <param name="configuration"></param>
        public HomeController(IHomeHelper homehelper, 
            IConfiguration configuration, ICustomerRepository repository)
        {
            _homehelper = homehelper;
            _configuration = configuration;
            this.repository = repository;
        }

        #endregion

        #region Action methods

        /// <summary>
        /// The min index page
        /// </summary>
        /// <param name="estimateDetails"></param>
        /// <returns></returns>  
        [Route("Home/Index/{isPriv}")]
        public ViewResult Index(bool isPriv)
        {
            if (ModelState.IsValid)
            {
                //bool isPriv = (bool)TempData["isPriv"];
                return View(new EstimateDetails() { isPrivilaged = isPriv });
            }
            return View("Error");                 
        }

        [Route("")]
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Authentication of user
        /// </summary>
        /// <param name="enteredUserName"></param>
        /// <param name="enteredPassword"></param>
        /// <returns></returns>
        
        /*Tried several options for redirecting to index page. */
        //[Route("/Home/Authenticate/{enteredUserName}/{enteredPassword}")]
        public IActionResult Authenticate(string enteredUserName, string enteredPassword)
        {
            if (ModelState.IsValid)
            {
                var storedAccount = repository.GetByUserName(enteredUserName);
                if (storedAccount != null && storedAccount.Password == enteredPassword)
                {
                    //return Redirect("https://localhost:44365/Home/Index?" + storedAccount.isPrivilaged.ToString());
                    //TempData["isPriv"] = storedAccount.isPrivilaged;
                    //var redirectUrl = Url.Action(nameof(Index));
                    // return Json(new { redirectToUrl = Url.Action("Index", "Home", new { isPriv = storedAccount.isPrivilaged } )});
                    return Json(new { isPriv = storedAccount.isPrivilaged });
                    //return this.RedirectToAction("Index", new { isPriv = storedAccount.isPrivilaged });

                    //return new JavaScriptResult($"window.location.href = 'https://localhost:44365/Home/Index? + {storedAccount.isPrivilaged.ToString()}");
                   
                }
                //ModelState.AddModelError(string.Empty, "Invalid login");
            }
            
            return View("Error");
        }

        /// <summary>
        /// Prints to a PDF File
        /// </summary>
        /// <param name="goldPrice"></param>
        /// <param name="goldWeight"></param>
        /// <param name="isPrivilaged"></param>
        /// <returns></returns>
        public void PrintToFile(double totalPrice, double discountedPrice, bool isPrivilaged)
        {
            string content = CreateContent(totalPrice, discountedPrice, isPrivilaged);
            _homehelper.WriteToFile(filePath, folderPath, content);           
        }

        /// <summary>
        /// Downloads the physical file
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadFile()
        {            
            return PhysicalFile(filePath, "application/text", Path.GetFileName(filePath));
        }

        /// <summary>
        /// Sends data to Modal view
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <param name="discountedPrice"></param>
        /// <param name="isPrivilaged"></param>
        /// <returns></returns>
        [Route("/Home/EstimatePopup/{totalPrice}/{discountedPrice}/{isPrivilaged}")]
        public IActionResult EstimatePopup(double totalPrice, double discountedPrice, bool isPrivilaged)
        {
            string content = CreateContent(totalPrice, discountedPrice, isPrivilaged);
            return PartialView("EstimatePopup", new EstimatePopupModel { ShowMessage = content });
        }

        public IActionResult PrintToPaper(double totalPrice, double discountedPrice, bool isPrivilaged)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Error view
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region private methods

        private string CreateContent(double totalPrice, double discountedPrice, bool isPrivilaged)
        {
            string content = $"The total Price is {totalPrice.ToString()}. ";
            if (isPrivilaged)
                content += $"The discounted Price is {discountedPrice.ToString()}";
            return content;
        }

        #endregion
    }


    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            this.Content = script;
            this.ContentType = "application/javascript";
        }
    }
}
