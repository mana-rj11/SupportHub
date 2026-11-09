public class ServicePriorite
{
    private readonly IReglePriorite _regle;

    public ServicePriorite(IReglePriorite regle)
    {
        _regle = regle;
    }

    public int CalculerPriorite(DemandeSupport demande)
    {
        return _regle.Calculer(demande);
    }
}

