using GestorDeEstoque.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization; // Importa recursos para serialização JSON


namespace GestorDeEstoque.Entities
{
    // Declara a classe Ebook, que herda de Produto e implementa a interface IEstoque
    public class Ebook : Produto, IEstoque
    {
        public string Autor { get; set; }
        // [JsonInclude] permite que esta propriedade privada seja salva/carregada no JSON
        [JsonInclude]
        private int _Vendas { get; set; }

        //Construtor da classe
        public Ebook(string nome, double preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }

        // Implementação do método AdicionarEntrada da interface IEstoque
        // Para Ebook, entrada não faz sentido pois é digital e não tem estoque físico limitado
        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um E-book, pois é um produto digital");
            Console.ReadLine();
        }

        // Implementação do método AdicionarSaida da interface IEstoque
        // Para Ebook, "saída" representa o registro de novas vendas
        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas do Ebook {Nome}");
            Console.WriteLine("Digite a quantidade de vendas que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Vendas += entrada;
            Console.WriteLine("Vendas registrada");
            Console.ReadLine();
        }

        // Implementação do método Exibir da interface IEstoque
        // Mostra as informações do Ebook no console
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
