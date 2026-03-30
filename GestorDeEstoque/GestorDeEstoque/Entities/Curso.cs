using GestorDeEstoque.Interfaces;
using System.Globalization; //Formatação de numeros e datas de acordo com a cultura (ex: formatação de preço)
using System.Text.Json.Serialization; //Importa recursos para serialização JSON

namespace GestorDeEstoque.Entities
{
    // Declara a classe Curso, que herda de Produto e implementa a interface IEstoque
    public class Curso : Produto, IEstoque
    {
        public string Autor { get; set; }

        // [JsonInclude] permite que esta propriedade privada seja salva/carregada no JSON
        [JsonInclude]
        private int _Vagas { get; set; }

        //Construtor
        public Curso(string nome, double preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }

        // Implementação do método AdicionarEntrada da interface IEstoque
        // No contexto de Curso, "entrada" significa adicionar vagas disponíveis
        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {Nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Vagas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        // Implementação do método AdicionarSaida da interface IEstoque
        // No contexto de Curso, "saída" significa consumir vagas (alunos matriculados, por exemplo)
        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {Nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer consumir: ");
            int consumir = int.Parse(Console.ReadLine());
            _Vagas -= consumir;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        // Implementação do método Exibir da interface IEstoque
        // Mostra as informações do curso no console
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
