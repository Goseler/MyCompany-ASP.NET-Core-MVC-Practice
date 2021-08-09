using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    public class UserActionsController : Controller
    {
        public IActionResult TechSupport()
		{
            return View(new TechMessage());
		}
    }
}
