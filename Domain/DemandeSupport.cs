public class DemandeSupport
{
    public string Titre { get; }
    public string Statut { get; private set; } = "Ouverte";

    public DemandeSupport(string titre)
    {
        if (string.IsNullOrWhiteSpace(titre))
        {
            throw new ArgumentException("Le titre est obligatoire.");
        }
        
        Titre = titre;
    }

    public void PrendreEnCharge()
    {
        Statut = "En cours";
    }
}