DemandeSupport demande1 = new DemandeSupport("Imprimante en panne");

Console.WriteLine(demande1.Titre);

DemandeSupport demande2 = new DemandeSupport("Panne réseau");

Console.WriteLine(demande2.Titre);

Console.WriteLine(demande1.Statut); // lit et affiche le statut actuel

demande2.PrendreEnCharge();

Console.WriteLine(demande2.Statut); // lit et affiche le nouveau statut


/** IReglePriorite regle = new ReglePrioriteUrgente();

int priorite = regle.Calculer(demande1);

Console.WriteLine($"Priorité : {priorite}");
*/


ServicePriorite service = new ServicePriorite(
    new ReglePrioriteUrgente()
);

int priorite = service.CalculerPriorite(demande1);

Console.WriteLine($"Priorité : {priorite}");


// DemandeSupport demandeInvalide = new DemandeSupport("   ");



/**
À toi : dans Program.cs, écris les trois instructions pour :
1. Afficher le statut de demande1.
2. Appeler demande1.PrendreEnCharge();.
3. Afficher de nouveau son statut.
*/

/** string titre = "Panneau réseau";
string statut = "Ouverte";

if (!EstTitreValide(titre))
{
    Console.WriteLine("Erreur : le titre est obligatoire");
} else
{
    Console.WriteLine($"Demande : {titre}");
    Console.WriteLine($"Statut : {statut}");
}

Console.WriteLine(EstTitreValide("Panne réseau"));
Console.WriteLine(EstTitreValide(""));

bool EstTitreValide(string titre)
{
    return !string.IsNullOrWhiteSpace(titre);
}


bool EstDescriptionValide(string description)
{
    return !string.IsNullOrWhiteSpace(description);
}

Console.WriteLine(EstDescriptionValide("   "));
Console.WriteLine(EstDescriptionValide("L'imprimante ne répond plus"));
*/