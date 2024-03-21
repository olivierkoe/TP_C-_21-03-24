using orgaRallyClassLibrary.Classes;


class Program
{
    public static void Main(string[] args)
        {
            gestionVehicules gestionVehicules = new gestionVehicules();
    
            gestionVehicules.Action();
            double valeur = Convert.ToDouble(Console.ReadLine());
            if (valeur != null && valeur != 0 && valeur > 0 && valeur <= 8)
            {
                switch (valeur)
                {
                    case 1:
                        //Créer un Véhicule et le rajouter à la liste
                        int numero;
                        int puissance;
                        decimal poids;
                        string type;
                        Console.WriteLine("Marque (Sans chiffre) ?");
                        string? marque = Console.ReadLine();
                        Console.WriteLine("Modèle ?");
                        string? modele = Console.ReadLine();
                        Console.WriteLine("Numéro (entre 4 et 6 chiffres) ?");
                        bool saisieNumeroValide = !int.TryParse(Console.ReadLine(), out numero);
                        //bool saisieNumValide = int.TryParse(Console.ReadLine(), out numero);
                        Console.WriteLine("Quel type? v pour voiture, c pour camion");
                        type = Console.ReadLine();

                        if(type == "v")
                            {
                                Console.WriteLine("Puissance ?");
                                bool saisiePuissanceValide = !int.TryParse(Console.ReadLine(), out puissance);
                                Voiture voiture = new Voiture(numero, marque!,modele!,puissance);
                                gestionVehicules.Create(voiture );
                                Console.WriteLine("Véhicules créés :");
                            }
                        else if (type == "c")
                            {
                                Console.WriteLine("Poids ?");
                                bool saisiePoidsValide = !decimal.TryParse(Console.ReadLine(), out poids);
                                Camion camion = new Camion(numero, marque!, modele!, poids);
                                gestionVehicules.Create(camion);
                                Console.WriteLine("Véhicules créés :");
                            }
                        foreach (var Vehicule in gestionVehicules.ReadAll())
                            {
                                Console.WriteLine($"Numéro : {Vehicule.Numero}, Marque : {Vehicule.Marque}, modèle : {Vehicule.Modele}");
                            }
                        break;

                    case 2:
                        // Voir un véhicule par son numéro
                        Console.WriteLine("Numéro (entre 4 et 6 chiffres) ? ");
                        int numeroAChercher;
                        bool saisieValide = !int.TryParse(Console.ReadLine(), out numeroAChercher);
                        var vehicule = gestionVehicules.ReadByNum(numeroAChercher, gestionVehicules.getListe());

                        if (vehicule != null)
                            {
                                Console.WriteLine($"Marque: {vehicule.Marque}, Modèle: {vehicule.Modele}, Numéro: {vehicule.Numero}");
                            }
                        else
                            {
                                Console.WriteLine("Véhicule non trouvé.");
                            }
                        break;

                    case 3:
                        int numero3;
                        int puissance3;
                        decimal poids3;
                        string type3;
                        Console.WriteLine("Formulaire de modificattion");
                        Console.WriteLine("Numéro (entre 4 et 6 chiffres) ?");
                        bool saisieNumeroValide3 = !int.TryParse(Console.ReadLine(), out numero3);
                        Console.WriteLine("Marque (Sans chiffre) ?");
                        string? marque3 = Console.ReadLine();
                        Console.WriteLine("Modèle ?");
                        string? modele3 = Console.ReadLine();
                        Console.WriteLine("Quel type? v pour voiture, c pour camion");
                        type3 = Console.ReadLine();

                        if(type3 == "v")
                            {
                                Console.WriteLine("Puissance (en kN) ?");
                                bool saisiPuissancveValide3 = !int.TryParse(Console.ReadLine(), out puissance3);
                                Voiture voitureModifier = new Voiture(numero3, marque3!, modele3!, puissance3);
                                gestionVehicules.Update(voitureModifier);
                                Console.WriteLine("Véhicules mis à jour :");
                            }
                        else if (type3 == "c")
                            {
                                Console.WriteLine("Poids (en Tonnes) ?");
                                bool saisiPPoidsValide3 = !decimal.TryParse(Console.ReadLine(), out poids3);
                                Camion camionModifier = new Camion(numero3, marque3!, modele3!, poids3);
                                gestionVehicules.Update(camionModifier);
                                Console.WriteLine("Véhicules mis à jour :");
                            }
                        foreach (var vehicule3 in gestionVehicules.ReadAll())
                            {
                                Console.WriteLine($"Numéro : {vehicule3.Numero}, Marque : {vehicule3.Marque}, modèle : {vehicule3.Modele}");
                            }
                        break;

                    case 4:
                        //Console.WriteLine("Supprimer un véhicule "); 
                        Console.Write("Formulaire de supression ");
                        Console.Write("Numéro (entre 4 et 6 chiffres) ? ");
                        int numeroAChercher4;
                        bool saisieValide4 = !int.TryParse(Console.ReadLine(), out numeroAChercher4);
                        var vehicule4 = gestionVehicules.ReadByNum(numeroAChercher4, gestionVehicules.getListe());
                        if (vehicule4 != null)
                            {
                                gestionVehicules.Delete(numeroAChercher4);
                                Console.WriteLine($"Marque: {vehicule4.Marque}, Modèle: {vehicule4.Modele}, Numéro: {vehicule4.Numero}");
                            }
                        else
                            {
                                Console.WriteLine("Véhicule non trouvé.");
                            }
                        break;

                
                    case 5: //Console.WriteLine("Trier les véhicules "); 

                        Console.WriteLine("Filtrer les véhicules ");
                        var vehiculesTries = gestionVehicules.getListe();
                        foreach (var item in vehiculesTries)
                            {
                                Console.WriteLine($"{item.Marque} {item.Modele} {item.Numero}");
                            }

                        break;


                    case 6: 
                        // Console.WriteLine("filtre les véhicules "); 
                        Console.WriteLine("Comment voulez vous Filtrer votre recherche? tapez : Numero, Marque, Modele ");
                        string? saisie1 = Console.ReadLine();
                        var L = gestionVehicules.getListe();

                        foreach (var v in L)
                        {
                            if (saisie1 == "Numero")
                                {
                                    Console.WriteLine($"Numéro: {v.Numero}, Marque: {v.Marque}, Modèle: {v.Modele}");
                                }
                            else if (saisie1 == "Marque")
                                {
                                    Console.WriteLine($" Marque: {v.Marque},Numéro: {v.Numero}, Modèle: {v.Modele}");
                                }
                            else if (saisie1 == "Modele")
                                {
                                    Console.WriteLine($"Modèle: {v.Modele},Marque: {v.Marque},Numéro: {v.Numero}");
                                }
                            else
                                {
                                    Console.WriteLine("Erreur Veuillez entrer une des trois proposition");
                                }
                        }
                        break;


                    case 7: //Console.WriteLine("Sauvegarder les véhicules");
                        gestionVehicules.Save();
                        Console.WriteLine("Véhicules sauvegardés avec succès.");
                        break;     
                }
            }
            else
            {
                Console.WriteLine("Veuillez renseigner un chiffre entre 1 et 7");
            }
        }
}