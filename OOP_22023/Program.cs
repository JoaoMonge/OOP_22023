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

app.MapGet("/", () => "Hello 22023");
app.MapGet("/ufcd", () => "3935");
app.MapGet("/morango", () => morango.cor);

app.Run();


class Fruta
{
    //Encapsulamento que serve para proteger as variáveis de acessos indevidos
    public string nome;
    public string cor;
    public double precoKg;

    public Fruta(string nome,string cor,double precoKg)
    {
        this.nome = nome;
        this.cor = cor;
        this.precoKg = precoKg;
    }
}
