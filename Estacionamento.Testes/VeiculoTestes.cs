using EstacionamentoConsole;
using EstacionamentoConsole.Models;
using NuGet.Frameworks;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        //Padrão A.A.A
        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]

        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert 
            Assert.Equal(100, veiculo.VelocidadeAtual);


        }

        [Fact]
        public void TestaVeiculoFrearcComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert 
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n°2")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Ignore")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            var carro = new Veiculo()
            {
                Proprietario = "Carlos Silva",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ZAP-7446",
                Cor = "Verde",
                Modelo = "Variante"
            };

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
            // Contains permite veirificar se há um determinado valor
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "As";

            //Assert
            var mensagem = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Proprietario = nomeProprietario
            ) ;

            Assert.Equal(" Nome de proprietário deve ter no mínimo 3 caracteres.", mensagem.Message);

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placaVeiculo = "BCBF4789";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placaVeiculo
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }


    }
}