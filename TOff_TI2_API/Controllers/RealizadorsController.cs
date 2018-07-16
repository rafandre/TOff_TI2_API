using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using TimeOff.Models;
using TOff_TI2_API.Models;

namespace TimeOff.Api
{
    public class RealizadorsController : ApiController
    {
        //referência para a base de dados  
        private DbCtxt db = new DbCtxt();

        // GET: api/Realizadors/5
        [HttpGet, Route("api/realizadores")]
        public IHttpActionResult GetRealizador()
        {
            //codigo 
            var resultado = db.Realizador.Select(
               aa => new
               {
                   id = aa.Id,  // Retorna o Id do Realizador
                   nome = aa.NomeRealizador, // Retorna o Titulo do Filme 
                   ano = aa.DataNasc, // Retorna o Ano de Lançamento 
                   sinopse = aa.Biografia, //Rertorna a Biografia do Realizador 
               });

            return Ok(resultado);
        }

        // GET: api/Realizadors/5
        [HttpGet, Route("api/realizador/{id}")]
        public IHttpActionResult GetRealizador(int id)
        {
            //codigo 
            var resultado = db.Realizador.Select(
               aa => new
               {
                   id = aa.Id,  // Retorna o Id do Realizador
                   nome = aa.NomeRealizador, // Retorna o Titulo do Filme 
                   ano = aa.DataNasc, // Retorna o Ano de Lançamento 
                   sinopse = aa.Biografia, //Rertorna a Biografia do Realizador 
                   imagem = aa.ImagemRealizador
               }).Where(r => r.id == id).First();

            if (resultado == null) return NotFound();
            var realizador = new
            {
                id = resultado.id,  // Retorna o Id do Realizador
                nome = resultado.nome, // Retorna o Titulo do Filme 
                ano = resultado.ano.ToString("dd/MM/yyyy"), // Retorna o Ano de Lançamento 
                sinopse = resultado.sinopse, //Rertorna a Biografia do Realizador 
                imagem = resultado.imagem
            };
            return Ok(realizador);
        }

    }
}