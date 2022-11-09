﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Extensions.HtmlResponse(@$"<!doctype html>
<html>
    <head><title>miniHTML</title></head>
    <body>
        <h1>Hello World</h1>
        <a href='/curso'>Goto curso</a>
        <p>The time on the server is {DateTime.Now:O}</p>
    </body>
</html>"));
app.MapGet("/curso", () => "22023");

app.Run();

static class CustomResultExtensions
{
    public static IResult HtmlResponse(this IResultExtensions extensions, string html)
    {
        return new CusomtHTMLResult(html);
    }
}

class CusomtHTMLResult : IResult
{
    private readonly string _htmlContent;
    public CusomtHTMLResult(string htmlContent)
    {
        _htmlContent = htmlContent;
    }
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_htmlContent);
        await httpContext.Response.WriteAsync(_htmlContent);
    }
}
