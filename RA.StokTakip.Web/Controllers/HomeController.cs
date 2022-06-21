using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ra.StokTakip.Business.IServices;
using RA.StokTakip.Entities.Model;
using RA.StokTakip.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RA.StokTakip.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeService _employeService;
        public HomeController(ILogger<HomeController> logger, IEmployeService employeService)
        {
            _logger = logger;
            _employeService = employeService;
        }

        public async Task<IActionResult> Index()
        {
            var returnDto = await _employeService.GetAll();
            if (returnDto.StatusCode == 200)
                return View(returnDto.Data);
            else
            {
                TempData["Error"] = returnDto.Error;
                return View(new List<Employe>());
            }
        }
        public async Task<IActionResult> EmployeView(int id = 0)
        {
            if (id == 0) return View(new Employe());
            var returnDto = await _employeService.GetById(id);
            if (returnDto.StatusCode == 200)
                return View(returnDto.Data);
            else
            {
                TempData["Error"] = returnDto.Error;
                return View(new Employe());
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmploye(Employe employe)
        {
            var returnDto = await _employeService.Create(employe);
            if (returnDto.StatusCode != 200)
                TempData["Error"] = returnDto.Error;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmploye(Employe employe)
        {
            var returnDto = await _employeService.Update(employe);
            if (returnDto.StatusCode != 200)
                TempData["Error"] = returnDto.Error;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            var returnDto = await _employeService.Delete(id);
            if (returnDto.StatusCode != 200)
                TempData["Error"] = returnDto.Error;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ActivePasiveEmploye(int id, bool pasiveFlag)
        {
            var dataDto = await _employeService.GetById(id);
            if (dataDto.StatusCode != 200)
            {
                TempData["Error"] = dataDto.Error;
                return RedirectToAction("Index");
            }
            else
            {
                dataDto.Data.PasiveFlag = pasiveFlag;
                var returnDto = await _employeService.Update(dataDto.Data);
                if (returnDto.StatusCode != 200)
                    TempData["Error"] = returnDto.Error;
                return RedirectToAction("Index");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
