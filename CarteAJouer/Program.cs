

using CarteAJouer;

Carte[] paquet = new Carte[52]; 

int cartesCreee = 0;
foreach( Couleur couleur in Enum.GetValues<Couleur>())
{
    foreach( Valeur valeur in Enum.GetValues<Valeur>())
    {
        //paquet[cartesCreee++] = new Carte(valeur, couleur);
        paquet[cartesCreee].valeur = valeur;
        paquet[cartesCreee++].couleur = couleur;
    }
}

foreach( Carte carte in paquet)
{
    Console.WriteLine($"{carte.valeur} de { carte.couleur }");
}