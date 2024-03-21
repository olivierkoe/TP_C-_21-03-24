using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orgaRallyClassLibrary.Classes
{
    public abstract class Vehicule
        {
            public int Numero { get; set; }
            public string Marque {get; set;}
            public string Modele { get; set; }
            public Vehicule(int numero, string marque, string modele)
                {
                    Numero = numero;
                    Marque = marque;
                    Modele = modele;
                }

            public virtual string ToString()
                {
                    return $"Numero : {Numero}, marque : {Marque}, modèle : {Modele}";
                }
        }
}
