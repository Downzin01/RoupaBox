namespace RoupaBox.Features.Cadastro
{
    internal class CadastroProduto
    {
        public CadastroProduto(string produto)
        {
            DescricaoProduto = produto;
        }
        public string DescricaoProduto { get; set; }
        public string MarcaProduto { get; set; }
        public string TamanhoProduto { get; set; }
        public string CorProduto { get; set; }
        public string CategoriaProduto { get; set; }
        public double ValorPorduto { get; set; }
        public double PesoProduto { get; set; }
    }
}

