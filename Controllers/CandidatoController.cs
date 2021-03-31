using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeEmpregare.Controllers
{
    public class CandidatoController : Controller
    {

        public IActionResult Index()
        {
            return View("Cadastro");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
