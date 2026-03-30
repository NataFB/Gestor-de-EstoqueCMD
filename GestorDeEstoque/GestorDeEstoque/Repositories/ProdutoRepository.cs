using System.Text.Json; // Importa recursos para serialização/deserialização JSON
using GestorDeEstoque.Entities;

namespace GestorDeEstoque.Repositories
{
    public class ProdutoRepository // Classe responsável por salvar e carregar produtos em um arquivo JSON
    {
        private readonly string caminho; // Campo privado que armazena o caminho completo do arquivo JSON, O readonly é um modificador que impede que o valor de um campo seja alterado depois que o objeto foi criado.

        // CONSTRUTOR
        public ProdutoRepository()
        {
            // Obtém o diretório onde o executável do programa está rodando
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            // Cria um objeto DirectoryInfo para navegar pelas pastas a partir do executável
            DirectoryInfo directory = new DirectoryInfo(basePath);

            // Sobe de pasta em pasta até encontrar a pasta que contém o arquivo .csproj (raiz do projeto)
            // Isso garante que o arquivo JSON seja salvo na pasta correta mesmo ao rodar pelo Visual Studio
            while (directory != null && directory.GetFiles("*.csproj").Length == 0)
                directory = directory.Parent;
            // Se não encontrou nenhuma pasta com .csproj, lança uma exceção informando o problema
            if (directory == null)
                throw new Exception("Pasta do projeto não encontrada.");
            // Monta o caminho para a subpasta "Data" dentro da pasta raiz do projeto
            string dataPath = Path.Combine(directory.FullName, "Data");
            // Se a pasta "Data" não existir, cria ela automaticamente
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);
            // Define o caminho completo do arquivo JSON onde os produtos serão salvos
            caminho = Path.Combine(dataPath, "produtos.json");
        }

        // Método que serializa a lista de produtos e salva no arquivo JSON
        public void Salvar(List<Produto> produtos)
        {
            // Configura as opções de serialização — WriteIndented formata o JSON com identação para facilitar leitura
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            // Converte a lista de produtos para uma string no formato JSON
            string json = JsonSerializer.Serialize(produtos, options);
            // Escreve (ou sobrescreve) o arquivo JSON com o conteúdo serializado
            File.WriteAllText(caminho, json);
        }

        // Método que lê o arquivo JSON e retorna a lista de produtos desserializada
        public List<Produto> Carregar()
        {
            // Se o arquivo ainda não existe (primeira execução), retorna uma lista vazia
            if (!File.Exists(caminho))
                return new List<Produto>();

            // Lê todo o conteúdo do arquivo JSON como texto
            string json = File.ReadAllText(caminho);

            // Converte o JSON de volta para uma lista de objetos Produto
            // O operador ?? garante que, se a desserialização retornar null, uma lista vazia seja retornada
            return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
            // O operador ?? é chamado de "null-coalescing operator" (operador de coalescência nula)
            // Ele funciona como uma verificação de segurança:
            // "Se o lado esquerdo for null, use o lado direito como valor padrão"
        }
    }
}