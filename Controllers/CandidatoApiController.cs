using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testeEmpregare.Models;

namespace testeEmpregare.Controllers
{
    [Route("api/Candidato")]
    [ApiController]
    public class CandidatoApiController : ControllerBase
    {


        private ResultModel Validar(CadastroCandidatoModel cadastroAtualizado, CadastroCandidatoModel cadastroExistente)
        {
            if (string.IsNullOrWhiteSpace(cadastroAtualizado.Nome))
            {
                return new ResultModel() { Success = false, Message = "Insira o nome" };
            }

            if (string.IsNullOrWhiteSpace(cadastroAtualizado.Email))
            {
                return new ResultModel() { Success = false, Message = "Insira o e-mail" };
            }
            if (string.IsNullOrWhiteSpace(cadastroAtualizado.Senha))
            {
                return new ResultModel() { Success = false, Message = "Insira a senha" };
            }
            if (string.IsNullOrWhiteSpace(cadastroAtualizado.Telefone))
            {
                return new ResultModel() { Success = false, Message = "Insira o telefone" };
            }
            if (cadastroAtualizado.Senha.Length <= 5)
            {
                return new ResultModel() { Success = false, Message = "Sua senha precisa ter pelo menos 6 dígitos" };
            }
            if (cadastroAtualizado.Nome.Length <= 3)
            {
                return new ResultModel() { Success = false, Message = "Seu nome precisa ter pelo menos três dígitos" };
            }

            var candidatoEncontrado = CandidatosDb.Candidatos.Any((c) => c.Email == cadastroAtualizado.Email && c != cadastroExistente);
            if (candidatoEncontrado)
            {
                return new ResultModel() { Success = false, Message = "E-mail já cadastrado" };
            }

            return new ResultModel() { Success = true };
        }


        [HttpPost()]
        public JsonResult Post(CadastroCandidatoModel cadastroCandidato)
        {
            var result = Validar(cadastroCandidato, null);
            if (result.Success)
            {
                CandidatosDb.Candidatos.Add(cadastroCandidato);
            }
            return new JsonResult(result);
        }

        [HttpGet()]
        public JsonResult Get()
        {
            return new JsonResult(CandidatosDb.Candidatos);
        }

        [HttpGet("{email}")]
        public JsonResult Get([FromRoute] string email)
        {
            var candidatoEncontrado = CandidatosDb.Candidatos.FirstOrDefault((c) => c.Email == email);
            return new JsonResult(candidatoEncontrado);
        }

        [HttpPut("{email}")]
        public JsonResult Put(string email, CadastroCandidatoModel atualizacaoCandidato)
        {
            var candidatoEncontrado = CandidatosDb.Candidatos.FirstOrDefault((c) => c.Email == email);
            if (candidatoEncontrado == null)
            {
                return new JsonResult(new ResultModel() { Success = false, Message = "O candidato não foi encontrado" });
            }

            var result = Validar(atualizacaoCandidato, candidatoEncontrado);

            if (result.Success)
            {
                candidatoEncontrado.Email = atualizacaoCandidato.Email;
                candidatoEncontrado.Nome = atualizacaoCandidato.Nome;
                candidatoEncontrado.Senha = atualizacaoCandidato.Senha;
                candidatoEncontrado.Telefone = atualizacaoCandidato.Telefone;
            }

            return new JsonResult(result);
        }

    }
}