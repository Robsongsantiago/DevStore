using DevStore.Context;
using DevStore.DTO;
using DevStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public readonly ApplicationContext appcontext;

        public ProdutoController(ApplicationContext context)
        {
            this.appcontext = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var Produtos = this.appcontext.Produtos.Include(x => x.Categoria).ToList();
            return Ok(Produtos);

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var produto = this.appcontext.Produtos.Where(x => x.Id == id).ToList();
            return Ok(produto);

        }
        [HttpPost]
        public ActionResult Post(ProdutoDTO produtoDTO)
        {
            var categoria = this.appcontext.Categorias.Where(x => x.Id == produtoDTO.IdCategoria).FirstOrDefault();
            var produto = new Produto();
            produto.NomeProduto = produtoDTO.NomeProduto;
            produto.Descricao = produtoDTO.Descricao;
            produto.Preco = produtoDTO.Preco;
            produto.Categoria = categoria;
            this.appcontext.Produtos.Add(produto);
            this.appcontext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(ProdutoDTO produtoDTO)
        {
            try
            {
                var produto = this.appcontext.Produtos.Where(x => x.Id == produtoDTO.Id).FirstOrDefault();
                if (produto != null)
                {
                    produto.NomeProduto = produtoDTO.NomeProduto;
                    produto.Descricao = produtoDTO.Descricao;
                    this.appcontext.Produtos.Update(produto);
                    this.appcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Produto não encontrado");
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
                var produto = this.appcontext.Produtos.Where(x => x.Id != id).FirstOrDefault();
                if (produto != null)
                {
                    this.appcontext.Produtos.Remove(produto);
                    appcontext.SaveChanges();
                    return Ok();
                }
                else
                {
                    throw new Exception("Produto não encontrado");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
