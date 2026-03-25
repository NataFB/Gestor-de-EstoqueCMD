using GestorDeEstoque.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization;


namespace GestorDeEstoque.Entities
{
    public class Ebook : Produto, IEstoque
    {
        public string Autor { get; set; }
        [JsonInclude]
        private int _Vendas { get; set; }

        public Ebook(string nome, double preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um E-book, pois é um produto digital");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas do Ebook {Nome}");
            Console.WriteLine("Digite a quantidade de vendas que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Vendas += entrada;
            Console.WriteLine("Vendas registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Preço: {Preco.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Quantidade de vendas: {_Vendas}");
            Console.WriteLine("======================================");
        }
    }
}
