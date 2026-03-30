using GestorDeEstoque.Entities;
using GestorDeEstoque.Interfaces;
using GestorDeEstoque.Repositories;
using System.Globalization;

namespace GestorDeEstoque
{
    class Program
    {
        // Cria uma instância do repositório responsável por salvar e carregar produtos do arquivo JSON
        static ProdutoRepository repo = new ProdutoRepository();

        // Cria uma lista em memória que vai armazenar os produtos carregados
        static List<Produto> produtos = new List<Produto>();

        //Enum definindo as opções do menu, associando cada opção a um número para facilitar a leitura da escolha do usuário
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }

        static void Main(string[] args)
        {
            // Carrega a lista de produtos salvos no arquivo JSON para a memória
            produtos = repo.Carregar();

            // Variável de controle do loop principal; enquanto false, o programa continua rodando
            bool sair = false;

            // Loop principal do programa — continua rodando até o usuário escolher "Sair"
            while (!sair)
            {
                Console.WriteLine("SISTEMA DE ESTOQUE");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");

                int opcao = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                // Verifica qual opção foi escolhida e chama o método correspondente
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

                Console.Clear(); //Limpa a tela após cada operação para manter a interface limpa e organizada
            }
        }


        // Método auxiliar que chama o repositório para salvar a lista de produtos no arquivo JSON
        static void Salvar()
        {
            repo.Salvar(produtos);
        }

        // Método que exibe todos os produtos cadastrados na tela
        static void Listagem()
        {
            Console.WriteLine("===== LISTA DE PRODUTOS =====");
            int i = 0; // Variável usada como ID numérico para identificar cada produto na listagem
            foreach (var p in produtos)   // Percorre cada produto da lista
            {
                // Verifica se o produto implementa a interface IEstoque. Se sim, faz um cast para IEstoque e armazena na variável "e"
                Console.WriteLine($"ID: {i}");
                if (p is IEstoque e)
                {
                    // Chama o método Exibir() da interface
                    e.Exibir();
                }
                i++;
            }
            Console.ReadLine();
        }

        // Método que remove um produto da lista
        static void Remover()
        {
            Listagem(); // Exibe a listagem para o usuário saber os IDs disponíveis
            Console.WriteLine("Digite o ID do item que deseja remover da lista.");
            int id = int.Parse(Console.ReadLine());

            // Verifica se o ID é válido (não negativo e dentro do tamanho da lista)
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id); // Remove o produto na posição informada
                Salvar(); // Salva a lista atualizada no arquivo JSON
            }
        }

        // Método que registra entrada de estoque para um produto
        static void Entrada()
        {
            Listagem(); // Exibe a listagem para o usuário saber os IDs disponíveis
            Console.WriteLine("Digite o ID do item que deseja adicionar no estoque.");
            int id = int.Parse(Console.ReadLine());

            // Verifica se o produto na posição informada implementa IEstoque
            if (produtos[id] is IEstoque e)
            {
                e.AdicionarEntrada();// Chama o método AdicionarEntrada() do produto correspondente
                Salvar();// Salva a lista com o estoque atualizado
            }
        }

        // Método que registra saída de estoque para um produto
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do item que deseja Retirar do estoque.");
            int id = int.Parse(Console.ReadLine());

            if (produtos[id] is IEstoque e)
            {
                e.AdicionarSaida();// Chama o método AdicionarSaida() do produto correspondente
                Salvar();// Salva a lista com o estoque atualizado
            }
        }

        // Método que cadastra um novo produto na lista
        static void Cadastro()
        {
            // Exibe as opções de tipo de produto para o usuário
            Console.WriteLine("1-Físico 2-Ebook 3-Curso");
            int op = int.Parse(Console.ReadLine());

            // Solicita e lê o nome do produto
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            // Solicita e lê o preço, usando InvariantCulture para aceitar ponto como separador decimal
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Com base no tipo escolhido, cria o produto específico e adiciona na lista
            switch (op)
            {
                case 1:
                    // Produto físico requer o valor do frete além de nome e preço
                    Console.Write("Frete: ");
                    double frete = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    produtos.Add(new ProdutoFisico(nome, preco, frete));
                    break;

                case 2:
                    // Ebook requer o nome do autor
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    produtos.Add(new Ebook(nome, preco, autor));
                    break;

                case 3:
                    // Curso também requer o nome do autor
                    Console.Write("Autor: ");
                    string autor2 = Console.ReadLine();
                    produtos.Add(new Curso(nome, preco, autor2));
                    break;
            }

            Salvar();// Salva a lista com o novo produto incluído
        }
    }
}