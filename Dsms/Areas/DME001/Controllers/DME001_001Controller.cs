using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dsms.ViewModels;
using Dsms.Model;

namespace Dsms.Controllers
{
    public class DME001_001Controller : Controller
    {
        /// <summary>
        /// 接続情報を保持
        /// </summary>
        private readonly Connectioninfo _connectioninfo = null;

        public DME001_001Controller(IOptions<Connectioninfo> connectioninfo)
        {
            this._connectioninfo = connectioninfo.Value;
        }

        public  IActionResult Init()
        {
            DME001_001ViewModel viewModel = new DME001_001ViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(DME001_001ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(DME001_001Controller.Init), "RK002G01", new { area = "RK002" });
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}