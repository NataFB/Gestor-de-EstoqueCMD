using GestorDeEstoque.Interfaces;
using System.Text.Json.Serialization;
using System.Globalization;

namespace GestorDeEstoque.Entities
{
    public class ProdutoFisico : Produto, IEstoque
    {
        public double Frete { get; set; }
        [JsonInclude]
        private int _Estoque {  get; set; }

        public ProdutoFisico(string nome, double preco, double frete)
        {
            Nome = nome;
            Preco = preco;
            Frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {Nome}");
            Console.WriteLine("Digite a quantidade que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto {Nome}");
            Console.WriteLine("Digite a quantidade que você quer retirar: ");
            int retirada = int.Parse(Console.ReadLine());
            _Estoque -= retirada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Frete: {Frete.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Preço: {Preco.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Estoque restantes: {_Estoque}");
            Console.WriteLine("======================================");
        }
    }
}
