public class ReglePrioriteUrgente : IReglePriorite
{
    public int Calculer(DemandeSupport demande)
    {
        return 1;
    }
}