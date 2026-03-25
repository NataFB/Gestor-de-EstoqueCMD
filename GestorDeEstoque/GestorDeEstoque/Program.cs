using GestorDeEstoque.Entities;
using GestorDeEstoque.Interfaces;
using GestorDeEstoque.Repositories;
using System.Globalization;

namespace GestorDeEstoque
{
    class Program
    {
        static ProdutoRepository repo = new ProdutoRepository();
        static List<Produto> produtos = new List<Produto>();

        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }

        static void Main(string[] args)
        {
            produtos = repo.Carregar();

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("SISTEMA DE ESTOQUE");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");

                int opcao = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                switch (escolha)
                {
                    case Menu.Listar:
                        Listagem();
                        break;

                    case Menu.Adicionar:
                        Cadastro();
                        break;

                    case Menu.Remover:
                        Remover();
                        break;

                    case Menu.Entrada:
                        Entrada();
                        break;

                    case Menu.Saida:
                        Saida();
                        break;

                    case Menu.Sair:
                        sair = true;
                        break;
                }

                Console.Clear();
            }
        }

        static void Salvar()
        {
            repo.Salvar(produtos);
        }

        static void Listagem()
        {
            Console.WriteLine("===== LISTA DE PRODUTOS =====");
            int i = 0;
            foreach (var p in produtos)
            {
                Console.WriteLine($"ID: {i}");
                if (p is IEstoque e)
                {
                    e.Exibir();
                }
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do item que deseja remover da lista.");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do item que deseja adicionar no estoque.");
            int id = int.Parse(Console.ReadLine());

            if (produtos[id] is IEstoque e)
            {
                e.AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do item que deseja Retirar do estoque.");
            int id = int.Parse(Console.ReadLine());

            if (produtos[id] is IEstoque e)
            {
                e.AdicionarSaida();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("1-Físico 2-Ebook 3-Curso");
            int op = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            switch (op)
            {
                case 1:
                    Console.Write("Frete: ");
                    double frete = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    produtos.Add(new ProdutoFisico(nome, preco, frete));
                    break;

                case 2:
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    produtos.Add(new Ebook(nome, preco, autor));
                    break;

                case 3:
                    Console.Write("Autor: ");
                    string autor2 = Console.ReadLine();
                    produtos.Add(new Curso(nome, preco, autor2));
                    break;
            }

            Salvar();
        }
    }
}