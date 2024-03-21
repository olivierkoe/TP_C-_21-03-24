using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orgaRallyClassLibrary.Classes
{
    public class Camion : Vehicule
        {
            public decimal Poids { get; set; }
            public Camion(int Numero, string Marque, string Modele,  decimal poids) : base(Numero,Marque, Modele )
                {
                    Poids = poids;
                }

            public override string ToString()
                {
                    return base.ToString() + $" poids : {Poids} tonnes";
                }

        }
}
