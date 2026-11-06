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

    [Fact]
    public void AssignerIdentifiant_Valide_EnregistrementIdentifiant()
    {
        // Arrange
        DemandeSupport demande = new DemandeSupport("Panne réseau");

        // Act
        demande.AssignerIdentifiant(1);

        // Assert
        Assert.Equal(1, demande.Id);
    }

    [Fact]
    public void AssignerIdentifiant_Negatif_leveException()
    {
        //Arrange
        DemandeSupport demande = new DemandeSupport("Panne réseau");
         //Act + Assert
        Assert.Throws<ArgumentException>(() =>
            demande.AssignerIdentifiant(-1)
        );
    }

    [Fact]
    public void AssignerIdentifiant_DejaAttribuer_LeveException()
    {
        // Arrange
        DemandeSupport demande = new DemandeSupport("Panne réseau");
        demande.AssignerIdentifiant(1);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
            demande.AssignerIdentifiant(2)
        );
        Assert.Equal(1, demande.Id);
    }

    [Fact]
    public void AssignerIdentifiant_Zero_leveException()
    {
        // Arrange
        DemandeSupport demande = new DemandeSupport("Ouverte");

        // Act + Assert
        Assert.Throws<ArgumentException>(() =>
            demande.AssignerIdentifiant(0)
        );
    }

    [Fact]
    public void ObtenirParId_DemandeExistance_RetourneDemandeAjoutee()
    {
        // Arrange
        DemandeSupport demande = new DemandeSupport("Panne réseau");
        DemandeRepositoryMemoire repository = new DemandeRepositoryMemoire();
        repository.Ajouter(demande);

        // Act
        DemandeSupport? resultat = repository.ObtenirParId(demande.Id);
        Assert.Same(demande, resultat);
    }

    [Fact]
    public void ObtenirParId_DemandeExistance_RetourneNull()
    {
        // Arrange
        DemandeRepositoryMemoire repository = new ();

        // Act
        DemandeSupport? resultat = repository.ObtenirParId(1);
        Assert.Null(resultat);
    }

    // ajoute deux demandes au même repository, puis vérifie qu’elles reçoivent des identifiants différents
    [Fact]
    public void Ajouter_DeuxDemandes_AttribueDesIdentifiantsDifferents()
    {
        // Arrange
        DemandeSupport nomVariable1 = new DemandeSupport("Titre non vide");
        DemandeSupport nomVariable2 = new DemandeSupport("Titre non vide");
        DemandeRepositoryMemoire repository = new DemandeRepositoryMemoire();

        // Act
        repository.Ajouter(nomVariable1);
        repository.Ajouter(nomVariable2);

        // Assert
        Assert.NotEqual(nomVariable1.Id, nomVariable2.Id);
    }
}