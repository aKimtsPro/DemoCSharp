using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAJouer
{
    internal struct Carte
    {

        public Valeur valeur;
        public Couleur couleur;

        public Carte(Valeur valeur, Couleur couleur)
        {
            this.valeur = valeur;
            this.couleur = couleur;
        }

    }
}
