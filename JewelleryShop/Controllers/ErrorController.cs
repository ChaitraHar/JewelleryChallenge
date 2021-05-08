using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {            
            return View("Error");
        }
    }
}