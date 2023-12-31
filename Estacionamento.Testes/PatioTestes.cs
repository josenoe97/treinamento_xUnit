﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoConsole;
using EstacionamentoConsole.Models;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {

        private Veiculo veiculo;
        private Operador operador;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Pedro Silva";
        }



        [Fact]
        public void ValidaFaturamentoEstacionamentoComUmVeiculo()
        {
            //Arrange
            

            var estacionamento = new Patio();

            
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
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
            //var veiculo = new Veiculo();

            estacionamento.OperadorPatio = operador;

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
        public void LocalizaVeiculoNoPatioComBaseIdTicket(string proprietario,
                                            TipoVeiculo tipo,
                                            string placa,
                                            string cor,
                                            string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = tipo;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            //var veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "XZC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";


            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();

            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "XZC-8524";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";


            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
