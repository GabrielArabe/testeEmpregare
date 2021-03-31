using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testeEmpregare.Models;

namespace testeEmpregare.Controllers
{
    [Route("api/Login")]
    [ApiController]

    public class LoginApiController : ControllerBase
    {


        [HttpPost()]
        public JsonResult Post(CadastroCandidatoModel candidato)
        {
            var candidatoEncontrado = CandidatosDb.Candidatos.FirstOrDefault((c) => c.Email == candidato.Email && c.Senha == candidato.Senha);
            if (candidatoEncontrado == null)
            {
                return new JsonResult(new ResultModel() { Success = false, Message = "Usuário e/ou senha incorreta" }); 
            }
            if (string.IsNullOrWhiteSpace(candidato.Email))
            {
                return new JsonResult(new ResultModel() { Success = false, Message = "Insira seu e-mail para fazer login" });
            }
            if (string.IsNullOrWhiteSpace(candidato.Senha))
            {
                return new JsonResult(new ResultModel() { Success = false, Message = "Insira sua senha para fazer login" });
            }

            return new JsonResult(new ResultModel() { Success = true });
        }

    }




}
