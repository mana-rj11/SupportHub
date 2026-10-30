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

app.MapPost("/demandes", (CreerDemandeRequest request) =>
{
    try
    {
        CreerDemande creerDemande = new CreerDemande();

        DemandeSupport demande = creerDemande.Executer(request.Titre);

        return Results.Created("/demandes", demande);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();

public partial class Program { }