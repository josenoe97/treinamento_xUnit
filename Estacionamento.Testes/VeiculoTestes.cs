using EstacionamentoConsole;
using EstacionamentoConsole.Models;
using NuGet.Frameworks;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        
        //Padrão A.A.A
        
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert 
            Assert.Equal(100, veiculo.VelocidadeAtual);


        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert 
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}