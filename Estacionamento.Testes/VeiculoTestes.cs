using EstacionamentoConsole;
using EstacionamentoConsole.Models;
using NuGet.Frameworks;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        
        //Padrão A.A.A
        
        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert 
            Assert.Equal(100, veiculo.VelocidadeAtual);


        }

        [Fact(DisplayName = "Teste n°1")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert 
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Teste n°2")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName="Teste n°3", Skip ="Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
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
    }
}