namespace orgaRallyClassLibrary.Classes
{
    public class Voiture : Vehicule
        {
            public int Puissance { get; set; }

            public Voiture(int numero, string marque, string modele,int puissance) : base(numero, marque, modele)
                {
                    Puissance = puissance;
                }

            public override string ToString()
                {
                    return base.ToString() + $" puissance : {Puissance} kW";
                }

        }
}
