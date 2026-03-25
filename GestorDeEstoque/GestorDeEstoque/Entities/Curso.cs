using GestorDeEstoque.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GestorDeEstoque.Entities
{
    public class Curso : Produto, IEstoque
    {
        public string Autor { get; set; }
        [JsonInclude]
        private int _Vagas { get; set; }

        public Curso(string nome, double preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {Nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Vagas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {Nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer consumir: ");
            int consumir = int.Parse(Console.ReadLine());
            _Vagas -= consumir;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Preço: {Preco.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Vagas restantes: {_Vagas}");
            Console.WriteLine("======================================");
        }
    }
}
