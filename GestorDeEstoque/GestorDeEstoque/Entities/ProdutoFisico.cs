using GestorDeEstoque.Interfaces;
using System.Text.Json.Serialization; //Importa recursos para serialização JSON
using System.Globalization; //Formatação de numeros e datas de acordo com a cultura (ex: formatação de preço)

namespace GestorDeEstoque.Entities
{
    // Declara a classe ProdutoFisico, que herda de Produto e implementa a interface IEstoque
    public class ProdutoFisico : Produto, IEstoque
    {
        public double Frete { get; set; }
        // [JsonInclude] permite que esta propriedade privada seja incluída na serialização/desserialização JSON
        [JsonInclude]
        private int _Estoque {  get; set; }

        //Construtor
        public ProdutoFisico(string nome, double preco, double frete)
        {
            Nome = nome;
            Preco = preco;
            Frete = frete;
        }

        // Implementação do método AdicionarEntrada da interface IEstoque
        // Registra a entrada de itens no estoque
        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {Nome}");
            Console.WriteLine("Digite a quantidade que você quer adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            _Estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        // Implementação do método AdicionarSaida da interface IEstoque
        // Registra a saída de itens do estoque
        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto {Nome}");
            Console.WriteLine("Digite a quantidade que você quer retirar: ");
            int retirada = int.Parse(Console.ReadLine());
            _Estoque -= retirada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        // Implementação do método Exibir da interface IEstoque
        // Mostra as informações do produto físico no console
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
