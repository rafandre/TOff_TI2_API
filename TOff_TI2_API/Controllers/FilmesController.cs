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

namespace TimeOff.Controllers
{
    public class FilmesAPIController : ApiController
    {
        //referência para a base de dados 
        private DbCtxt db = new DbCtxt();

        // CRUD: Obter uma lista de Agentes
        // GET: api/FilmesAPI
        [HttpGet,Route("api/filmes")]
        public IHttpActionResult GetFilmes()
        {
            var a = db.Filmes.Select(
                aa => new
                {
                    id = aa.Id,  // Retorna o Id do Filme
                    titulo = aa.Titulo, // Retorna o Titulo do Filme 
                    ano = aa.AnoLanc, // Retorna o Ano de Lançamento 
                    realizador = aa.Realizadores.Id,// Retorna o Id Realizador do Filme
                    realizadorNome = aa.Realizadores.NomeRealizador, //Retorna o Nome do Realizador 
                    categoria = aa.Categorias.Select(bb => new { bb.Nome, bb.Id }), // Retorna a Categoria do Filme 
                    atores = aa.Atores.Select(bb => new { bb.Id, bb.Nome }), // Retorna os Atores do Filme
                    imagem = aa.ImagensFilme, // Retorna o nomde da Imagem do Filme 
                    sinopse = aa.Sinopse, //Rertorna a Sinopse do Filme 
                    trailer = aa.LinkTrailer, //Retorna o Trailer do Filme 
                })

             .ToList();  // O ToList() executa a query na base de dados e guarda os resultados numa List<>.

            return Ok(a);
        }

        // GET: api/FilmesAPI/5
        [HttpGet, Route("api/filme/{id}")]
        public IHttpActionResult GetFilme(int id)
        {
            var filme = db.Filmes.Select(
                aa => new
                {
                    id = aa.Id,  // Retorna o Id do Filme
                    titulo = aa.Titulo, // Retorna o Titulo do Filme 
                    ano = aa.AnoLanc, // Retorna o Ano de Lançamento 
                    realizador = aa.Realizadores.Id,// Retorna o Id Realizador do Filme
                    realizadorNome = aa.Realizadores.NomeRealizador, //Retorna o Nome do Realizador 
                    categoria = aa.Categorias.Select(bb => new { bb.Nome, bb.Id }), // Retorna a Categoria do Filme 
                    atores = aa.Atores.Select(bb => new { bb.Id, bb.Nome }), // Retorna os Atores do Filme
                    imagem = aa.ImagensFilme, // Retorna o nomde da Imagem do Filme 
                    sinopse = aa.Sinopse, //Rertorna a Sinopse do Filme 
                    trailer = aa.LinkTrailer, //Retorna o Trailer do Filme 
                }).Where(aa => aa.id==id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

    }
    
}