namespace GestorDeEstoque.Interfaces
{
    // Declara a interface IEstoque — uma interface é um "contrato" que obriga
    // qualquer classe que a implemente a ter os métodos definidos aqui
    public interface IEstoque
    {
        void Exibir();
        void AdicionarEntrada();
        void AdicionarSaida();
    }
}
