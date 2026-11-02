public class DemandeRepositoryMemoire : IDemandeRepository
{
    private readonly Dictionary<int, DemandeSupport> _demandes = new();
    private int _prochainId = 1;


public void Ajouter(DemandeSupport demande)
{
    ArgumentNullException.ThrowIfNull(demande);

    lock (_demandes)
    {
        demande.AssignerIdentifiant(_prochainId);
        _demandes.Add(_prochainId, demande);
        _prochainId++;
    }
}

public DemandeSupport? ObtenirParId(int id)
    {
        lock (_demandes)
        {
            _demandes.TryGetValue(id, out DemandeSupport? demande);
            return demande;
        }
    }

}