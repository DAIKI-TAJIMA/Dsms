using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dsms.Areas.DME001.Controllers
{
    public class DME001_001Controller : Controller
    {
        public IActionResult Init()
        {
            return View();
        }
    }
}