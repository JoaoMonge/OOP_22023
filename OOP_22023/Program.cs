using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Fruta banana = new Fruta("banana", "amarelo", 1.4);
Fruta morango = new Fruta("morango", "vermelho", 3.5);
Fruta maca = new Fruta("maca", "verde", 1.2);

Carro mercedes = new Carro("Mercedes", "C220", "AA-00-BB", "LigeiroPassageiros");
Carro peugeot = new Carro("Peugeot", "206", "FF-13-45", "LigeirosPassageiros");

String nome = "Joao";

app.MapGet("/", () => "Hello 22023");
app.MapGet("/ufcd", () => "3935");
app.MapGet("/morango", () => morango.calcularPreco(0.200));
app.MapGet("/banana", () => banana.toString());
app.MapGet("/end/{letra}", (string letra) => nome.EndsWith(letra));
app.MapGet("/morango/{tipo}",(string tipo) => tipo=="cor" ? morango.cor : morango.nome);
app.Run();



class Fruta
{
    //Encapsulamento que serve para proteger as variáveis de acessos indevidos
    public string nome;
    public string cor;
    public double precoKg;

    public Fruta(string nome, string cor, double precoKg)
    {
        this.nome = nome;
        this.cor = cor;
        this.precoKg = precoKg;
    }

    public String toString()
    {
        String texto = $"Nome: {nome} Cor: {cor} Preço: {precoKg}";
        return texto;
    }

    public String calcularPreco(double peso) {
        double resultado = peso*precoKg;
        String texto = $"O custo de {peso} kg de {nome} foi {resultado}";
        return texto;
    }
}


class Carro {
    public String marca;
    public String modelo;
    public String matricula;
    public String categoriaVeiculo;

    //Constructor da classe
    public Carro(String marca, String modelo, String matricula,String categoriaVeiculo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.matricula = matricula;
        this.categoriaVeiculo = categoriaVeiculo;
    }

}