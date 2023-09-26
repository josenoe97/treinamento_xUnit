using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoConsole;
using EstacionamentoConsole.Models;

namespace Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "José Edson Noé";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "BCB-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "ASD-1498", "preto", "Gol")]
        [InlineData("José Silva", TipoVeiculo.Automovel, "POL-1298", "branco", "Etios")]
        [InlineData("Carlos Noe", TipoVeiculo.Automovel, "ADF-1423", "azul", "Opala")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                       TipoVeiculo tipo,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = tipo;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatio(string proprietario,
                                            TipoVeiculo tipo,
                                            string placa,
                                            string cor,
                                            string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = tipo;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            Patio estanacionamento = new Patio();
            var veiculo = new Veiculo()
            {
                Proprietario = "José Silva",
                Placa = "XZC-8524",
                Cor = "Verde",
                Modelo = "Opala",
            };

            estanacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();

            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "XZC-8524";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";


            //Act
            Veiculo alterado = estanacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}
