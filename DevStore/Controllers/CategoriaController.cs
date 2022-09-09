using DevStore.Context;
using DevStore.DTO;
using DevStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DevStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly ApplicationContext appcontext;

        public CategoriaController(ApplicationContext context)
        {
            this.appcontext = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var categorias = this.appcontext.Categorias.ToList();
            return Ok(categorias);

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var categoria = this.appcontext.Categorias.Where(x => x.Id == id).ToList();
            return Ok(categoria);

        }
        [HttpPost]
        public ActionResult Post(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria();
            categoria.NomeCategoria = categoriaDTO.NomeCategoria;
            categoria.Descricao = categoriaDTO.Descricao;
            this.appcontext.Categorias.Add(categoria);
            this.appcontext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(CategoriaDTO categoriaDTO)
        {
            try
            {
                var categoria = this.appcontext.Categorias.Where(x => x.Id == categoriaDTO.Id).FirstOrDefault();
                if (categoria != null)
                {
                    categoria.NomeCategoria = categoriaDTO.NomeCategoria;
                    categoria.Descricao = categoriaDTO.Descricao;
                    this.appcontext.Categorias.Update(categoria);
                    this.appcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Categoria não encontrado");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("{Id}")]
        public ActionResult Excluir(int id)
        {
            try
            {
                var categoria = this.appcontext.Categorias.Where(x => x.Id != id).FirstOrDefault();
                if (categoria != null)
                {
                    this.appcontext.Categorias.Remove(categoria);
                    appcontext.SaveChanges();
                    return Ok();
                }
                else
                {
                    throw new Exception("Categoria não encontrado");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
