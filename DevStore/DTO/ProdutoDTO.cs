namespace DevStore.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int IdCategoria { get; set; }
    }
}
