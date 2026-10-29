var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Bienvenue dans SupportHub");

app.MapGet("/demandes/exemple", () =>
{
    CreerDemande creerDemande = new CreerDemande();

    DemandeSupport demande = creerDemande.Executer(
        "Imprimante en panne"
    );

    return demande;
});

app.Run("http://localhost:5000");