var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/curso", () => "O curso atual é o 3935.");
app.MapGet("/iefp", () => "22023.");


app.Run();

