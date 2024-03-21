using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace orgaRallyClassLibrary.Classes
{
    public class gestionVehicules 
        {
            private List<Vehicule> vehicules = new List<Vehicule>();

            public string filePath { get; private set; }

            public void Create(Vehicule vehicule)
                {
                    vehicules.Add(vehicule);
                }

            public Vehicule ReadByNum(int numero)
                {
                    return vehicules.Find(v => v.Numero == numero);
                }

            public List<Vehicule> ReadAll()
                {
                    return vehicules;
                }
            public static List<Vehicule> getListe()
                {
                    return new List<Vehicule>
                        {
                            new Camion(1024,  "Iveco", "Eurocargo",12),
                            new Voiture(1025,"Renault", "clio",  105),
                            new Camion(1256,"MAN", "Eurocargo",  12),
                            new Voiture(1650,"Peugeot", "307",  130),
                            new Camion(2035,"VOLVO", "Eurocargo",  12),
                            new Voiture(1532,"Porch", "Boxster",  220),
                            new Camion(3403,"RENAULT", "Truck T range",  44),
                            new Voiture(3709,"Mazda", "MX-5",  132),
                            new Camion(3654,"MERCEDES", "Eurocargo",  12),
                            new Voiture(1089,"Tesla", "Model X",  493)
                        };
                }

            public static void Action()
                {
                    Console.WriteLine("Quelle action ?");
                    Console.WriteLine("1 - Créer un véhicule");
                    Console.WriteLine("2 - Voir véhicules");
                    Console.WriteLine("3 - Mettre à jour un véhicule");
                    Console.WriteLine("4 - Supprimer un véhicule");
                    Console.WriteLine("5 - Trier les véhicules");
                    Console.WriteLine("6 - Filtrer les véhicules");
                    Console.WriteLine("7 - Sauvegarder les véhicules");

                    Console.WriteLine("Entrez la valeur");
                }


            public static Vehicule ReadByNum(int numero, List<Vehicule> liste)
                {
                    return liste.FirstOrDefault(liste => liste.Numero == numero);
                }

            public static Vehicule ReadByModele(string modele, List<Vehicule> liste)
                {
                    return liste.FirstOrDefault(liste => liste.Modele == modele);
                }

            public void Update(Vehicule vehicule)
            {
                int index = vehicules.FindIndex(v => v.Numero == vehicule.Numero);
                if (index != -1)
                    {
                        vehicules[index] = vehicule;
                    }
                else
                    {
                        Console.WriteLine("Véhicule non trouvé.");
                    }
            }


            public List<Vehicule> Sort()
                {
                    return vehicules.OrderBy(v => v.Marque).ThenBy(v => v.Modele).ThenBy(v => v.Numero).ToList();
                }

            public void Delete(int numero)
            {
                Vehicule vehicule = vehicules.Find(v => v.Numero == numero);
                if (vehicule != null)
                    {
                        vehicules.Remove(vehicule);
                    }
                else
                    {
                        Console.WriteLine("Véhicule non trouvé.");
                    }
            }

            public void Save()
                {
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
                    string json = JsonConvert.SerializeObject(vehicules, Formatting.Indented, settings);
                    File.WriteAllText(filePath, json);
                }

            public void Upload()
            {
                if (File.Exists(filePath))
                {
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
                    string json = File.ReadAllText(filePath);
                    vehicules = JsonConvert.DeserializeObject<List<Vehicule>>(json, settings) ?? new List<Vehicule>();
                }
            }
        }
}
