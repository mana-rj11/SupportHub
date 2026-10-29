var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Bienvenue dans SupportHub");

app.MapGet("/demandes/exemple", () =>
{
    DemandeSupport demande = new DemandeSupport("Imprimante en panne");

    return demande;
});

app.Run("http://localhost:5000");