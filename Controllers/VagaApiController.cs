using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using testeEmpregare.Models;

namespace testeEmpregare.Controllers
{
    [Route("api/Vaga")]
    [ApiController]
    public class VagaApiController : ControllerBase
    {
        [HttpGet()]
        public JsonResult Get()
        {

            List<VagaModel> vagas = new List<VagaModel>() {
                new VagaModel
                {
                    cargo = "Desenvolvedor C# JR",
                    local = "Remoto",
                    salario = 3000
                },
                new VagaModel
                {
                    cargo = "Desenvolvedor C# PL",
                    local = "São Paulo/SP",
                    salario = 5000
                },
                new VagaModel
                {
                    cargo = "Desenvolvedor C# SR",
                    local = "São Paulo/SP",
                    salario = 10000
                },
                new VagaModel
                {
                    cargo = "Desenvolvedor C# PL",
                    local = "Rio de Janeiro/RJ",
                    salario = 5000
                },
                new VagaModel
                {
                    cargo = "Desenvolvedor Backend",
                    local = "Armação de Búzios/RJ",
                    salario = 5000
                },
                new VagaModel
                {
                    cargo = "Desenvolvedor Frontend",
                    local = "Remoto",
                    salario = 5000
                }

            };

            return new JsonResult(vagas);
        }

    }
}
