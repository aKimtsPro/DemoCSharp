
using DemoCSharpBase;

// Recap method 1

Personne p1;
p1.nom = "Luc";
p1.age = 41;

int age = 0;

// LECTURE de la variable par la méthode
// Le paramètre contiendra la copie de la valeur de la variable age
p1.CopyAge(age);

// ECRITURE de la variable par la méthode
// Il sera possible pour la méthode d'affecter directement la variable mais pas de récupérer sa valeur.
p1.CopyAge(out age);

// LECTURE/ECRITURE de la variable par la méthode
// La référence de la variable est donnée. On a alors accès à la variable age sous l'alias du param.
p1.AddAge(ref age);

Console.WriteLine(age);






// method 2
//

p1.age = 41;

int[] tab = new int[] { 0 };
int[] tab2 = tab;

p1.addAgeToTab(ref tab);

Console.WriteLine(tab[0]); // 41
Console.WriteLine(tab2[0]); // 0


// ATTENTION: les variables de type "tableau de" ne contiennent pas directement le tableau
// mais bien une référence vers le tableau.



// enum

// Les énumérations permettent de créer un type dont certaines valeurs peuvent 



// Il est possible d'incorporer dans nos enums une logique de Flags.
// Les valeurs de Right etant liés à des ordinaux puissances de 2, 


// le droit de lire et ecrire
Right r1 = Right.Read | Right.Write; // 0001 | 0010 = 0011
// le droit de lire et exécuter 
Right r2 = Right.Read | Right.Execute; // 0001 | 0100 = 0101

// le droit commun entre r1 et r2: cad le droit de lire
Right commonRight = r1 & r2; // 0011 & 0101 = 0001 // == Right.READ


if (r1.HasFlag(Right.Read))
{
    Console.WriteLine("Je lis"); // se produit
}

if (r1.HasFlag(Right.Write))
{
    Console.WriteLine("J'écris"); // se produit
}

if (r1.HasFlag(Right.Execute))
{
    Console.WriteLine("J'exécute"); // ne se produit pas
}


// Par cette partie, on comprend aussi qu'il est possible d'associer ma variable d'un type enum
// à des valeurs d'ordinaux non attribués dans sa déclaration.



// Il est possible de lier 2 valeurs au même ordinal mais cela peut conduire à des comportement non-souhaité
Console.WriteLine(Categorie.FRUIT == Categorie.LEGUME); // True

// Transformation enum -> string ou enum -> int
Console.WriteLine(Categorie.FRUIT.ToString()); // LEGUME
Console.WriteLine(Enum.GetName(Categorie.FRUIT)); // LEGUME
Console.WriteLine((int)Categorie.FRUIT); // 3



// Transformation string -> enum ou int -> enum
Console.WriteLine("- MEUBLE"); // 2
Console.WriteLine("- FRUIT"); // 3
Console.WriteLine("- LEGUME"); // 3
Console.WriteLine("- ELECTRONIQUE"); // 4
Categorie catDesir;
if (Enum.TryParse(Console.ReadLine(), out catDesir))
{
    Console.WriteLine($"votre choix est {catDesir}(ordinal: {(int)catDesir})");
}
// On remarque que donner un nombre non lié à une valeur déclarer de l'enum ne pose pas de problème.
// Le TryParse échoue quand:
// - on donne un nom (string) non déclaré dans l'enum
// - on donne un nombre hors des limites du int



// Sur la class Enum, on trouve une série de méthode pour plus interragir avec les enums
string? name = Enum.GetName(Categorie.FRUIT);
Console.WriteLine(name); // LEGUME

string[] names = Enum.GetNames(typeof(Categorie));


Console.WriteLine("--NAMES--");
foreach (string n in names) {
    Console.WriteLine(n);
}

Categorie[] values = Enum.GetValues<Categorie>();



// Du fait de leur nature numérique, il est possible, via casting, de réaliser des opérations
// arithmétiques sur les valeurs d'enum
Console.WriteLine(  (Categorie)((int)Categorie.MEUBLE + (int)Categorie.MEUBLE) );





