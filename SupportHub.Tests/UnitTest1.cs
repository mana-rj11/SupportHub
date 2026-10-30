using Xunit;

public class ReglePrioriteTests
{
    [Fact]
    public void RegleStandard_RetourneTrois()
    {
        // Arrange : préparer
        DemandeSupport demande = new DemandeSupport("Panne réseau");
        IReglePriorite regle = new ReglePrioriteStandard();

        // Act : exécuter.
        int resultat = regle.Calculer(demande);

        // Assert : vérifier 
        Assert.Equal(3, resultat);
    }

    [Fact]
    public void CreationDemande_TitreVide_LeveUneException()
    {
        // Arrange
        string titre = "";

        // Act + Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new DemandeSupport(titre);
        });
    }

    [Fact]
    public void CreationDemande_StatutInitial_EstOuverte()
    {
        // Arrange
        string titre = "Imprimante en panne";

        // Act 
        DemandeSupport demande = new DemandeSupport(titre);

        // Assert 
        Assert.Equal("Ouverte", demande.Statut);

    }
}