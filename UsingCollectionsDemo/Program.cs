using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiant = new SortedList();
            Console.Write("Combien d'étudiants voulez-vous saisir ? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Etudiant e = new Etudiant();
                e.NO = i;

                Console.WriteLine($"\n--- Étudiant {i} ---");
                Console.Write("Prénom : ");
                e.Prenom = Console.ReadLine();

                Console.Write("Nom : ");
                e.Nom = Console.ReadLine();

                Console.Write("Note Contrôle Continu : ");
                e.NoteCC = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir : ");
                e.NoteDevoir = double.Parse(Console.ReadLine());

                lstEtudiant.Add(e.NO, e);
            }

            // Choix pagination
            int lignesParPage = 5;
            Console.Write("\nChoisissez le nombre de lignes par page (5 à 15) : ");
            int choix = int.Parse(Console.ReadLine());
            if (choix >= 5 && choix <= 15)
                lignesParPage = choix;

            int page = 0;
            int totalPages = (int)Math.Ceiling((double)lstEtudiant.Count / lignesParPage);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--- Page {page + 1}/{totalPages} ---");

                double somme = 0;
                int start = page * lignesParPage;
                int end = Math.Min(start + lignesParPage, lstEtudiant.Count);

                for (int i = start; i < end; i++)
                {
                    Etudiant e = (Etudiant)lstEtudiant.GetByIndex(i);
                    double moy = e.Moyenne();
                    somme += moy;

                    Console.WriteLine($"NO: {e.NO}, Prénom: {e.Prenom}, Nom: {e.Nom}, " +
                                      $"NoteCC: {e.NoteCC}, NoteDevoir: {e.NoteDevoir}, Moyenne: {moy:F2}");
                }

                double moyenneClasse = somme / (end - start);
                Console.WriteLine($"\nMoyenne de la page: {moyenneClasse:F2}");

                Console.WriteLine("\nOptions: [S]uivant | [P]récedent | [Q]uitter");
                string option = Console.ReadLine().ToUpper();

                if (option == "S" && page < totalPages - 1) page++;
                else if (option == "P" && page > 0) page--;
                else if (option == "Q") break;
            }


        }
    }
}
