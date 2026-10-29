public class CreerDemande
{
    public DemandeSupport Executer(string titre)
    {
        return new DemandeSupport(titre);
    }
}