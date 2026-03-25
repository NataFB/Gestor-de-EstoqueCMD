using System.Text.Json;
using GestorDeEstoque.Entities;

namespace GestorDeEstoque.Repositories
{
    public class ProdutoRepository
    {
        private readonly string caminho;

        public ProdutoRepository()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directory = new DirectoryInfo(basePath);

            while (directory != null && directory.GetFiles("*.csproj").Length == 0)
                directory = directory.Parent;

            if (directory == null)
                throw new Exception("Pasta do projeto não encontrada.");

            string dataPath = Path.Combine(directory.FullName, "Data");

            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);

            caminho = Path.Combine(dataPath, "produtos.json");
        }

        public void Salvar(List<Produto> produtos)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(produtos, options);
            File.WriteAllText(caminho, json);
        }

        public List<Produto> Carregar()
        {
            if (!File.Exists(caminho))
                return new List<Produto>();

            string json = File.ReadAllText(caminho);

            return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }
    }
}