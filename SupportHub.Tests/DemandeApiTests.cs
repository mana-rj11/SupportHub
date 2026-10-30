using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;

public class DemandeApiTests
{
    [Fact]
    public async Task CreationDemande_TitreVide_Retourne400()
    {
        // Arrange : preparer l'API de test
        using var factory = new WebApplicationFactory<Program>();
        HttpClient client = factory.CreateClient();

        // Act : envoyer une requête POST
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "/demandes",
            new { titre = "  "}
        );

        // Assert : vérifier le code HTTP
        Assert.Equal(
            System.Net.HttpStatusCode.BadRequest,
            response.StatusCode
        );
    }
}