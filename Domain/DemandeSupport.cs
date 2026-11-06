public class DemandeSupport
{
    public string Titre { get; }
    public string Statut { get; private set; } = "Ouverte";
    public int Id { get; private set; }

    public DemandeSupport(string titre)
    {
        if (string.IsNullOrWhiteSpace(titre))
        {
            throw new ArgumentException("Le titre est obligatoire.");
        }
        
        Titre = titre;
    }

    public void AssignerIdentifiant(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException(
                "L'identifiant doit être positif."
            );
        }

        if (Id != 0)
        {
            throw new InvalidOperationException(
                "L'identifiant est déjà attribué"
            );
        }

        Id = id;
    }

    public void PrendreEnCharge()
    {
        Statut = "En cours";
    }
}