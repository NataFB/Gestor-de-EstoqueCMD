using System.Text.Json.Serialization;

namespace GestorDeEstoque.Entities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(ProdutoFisico), "ProdutoFisico")]
    [JsonDerivedType(typeof(Ebook), "Ebook")]
    [JsonDerivedType(typeof(Curso), "Curso")]
    public abstract class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}