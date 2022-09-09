using System.ComponentModel.DataAnnotations.Schema;

namespace DevStore.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
  
}

