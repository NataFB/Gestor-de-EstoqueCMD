using System.Text.Json.Serialization; // Importa recursos para serialização/deserialização de JSON com suporte a polimorfismo

namespace GestorDeEstoque.Entities
{
    // Atributo que habilita o polimorfismo na serialização JSON
    // Quando salvar/carregar o JSON, vai incluir uma propriedade "$type" para identificar o tipo real do objeto
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]

    // Informa ao serializador que ProdutoFisico é um tipo derivado de Produto, identificado como "ProdutoFisico" no JSON
    [JsonDerivedType(typeof(ProdutoFisico), "ProdutoFisico")]
    // Informa ao serializador que Ebook é um tipo derivado de Produto, identificado como "Ebook" no JSON
    [JsonDerivedType(typeof(Ebook), "Ebook")]
    // Informa ao serializador que Curso é um tipo derivado de Produto, identificado como "Curso" no JSON
    [JsonDerivedType(typeof(Curso), "Curso")]

    // Declara a classe Produto como abstrata — ela não pode ser instanciada diretamente,
    // servindo apenas como modelo base para ProdutoFisico, Ebook e Curso
    public abstract class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}