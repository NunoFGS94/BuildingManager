using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            //current data
            return View();
        }
    }
}
