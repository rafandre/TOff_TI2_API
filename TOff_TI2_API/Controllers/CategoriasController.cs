using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TimeOff.Models;
using TOff_TI2_API.Models;

namespace TimeOff.Api
{
    public class CategoriasController : ApiController
    {
        //referência para a base de dados 
        private DbCtxt db = new DbCtxt();

        // GET: api/Categorias/5
        [HttpGet, Route("api/categorias")]
        public IHttpActionResult GetCategorias()
        {
            //codigo
            var resultado = db.Categorias.Select(
                aa => new
                {
                    id = aa.Id,  // Retorna o Id da categoria  
                    nome = aa.Nome, // Retorna o Nome da categoria
                })
                .ToList();  // O ToList() executa a query na base de dados e guarda os resultados numa List<>.

            return Ok(resultado);
        }

    }
}