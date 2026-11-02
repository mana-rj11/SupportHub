public interface IDemandeRepository
{
    void Ajouter(DemandeSupport demande);

    DemandeSupport? ObtenirParId(int id);
}