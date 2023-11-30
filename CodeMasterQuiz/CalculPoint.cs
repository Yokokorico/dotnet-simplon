using System.Diagnostics;
using System.Drawing;

namespace Classes;
public class CalculPoint{
    const string sep = "\n\n--------------------------------------------------\n\n";

    public static void CalculDesPoints(int numroot, int numquestion, List<racineJson> source, Joueur joueur, string DifficulteQuestion, string DescriptifQuestion, Stopwatch stopwatch, string rep)
    {
        Int32.TryParse(rep, out int comparateur);
        if (comparateur == source[numroot].Quizz[0].Questions[numquestion].Resultat[0].Reponse)
        {
            stopwatch.Stop();
            Console.WriteLine($"Vous avez mis {stopwatch.ElapsedMilliseconds / 1000} secondes pour répondre\nBien joué !\n{sep}{DescriptifQuestion}{sep}");
            int temps = (int)stopwatch.ElapsedMilliseconds / 1000;
            PointsEnFonctionDuTemps(temps,joueur,DifficulteQuestion);
            Console.ReadLine();
            stopwatch.Reset();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"Mauvaise réponse ! C'était la réponse numéro {source[numroot].Quizz[0].Questions[numquestion].Resultat[0].Reponse}\n{sep}{DescriptifQuestion}{sep}\nAppuyer sur une touche pour continuer !");
            Console.ReadLine();
            Console.Clear();
        }
    }

    public static void PointsEnFonctionDuTemps(int temps,Joueur joueur,string DifficulteQuestion)
    {
        Int32.TryParse(DifficulteQuestion,out int diffi);
        double points=0;
        if(temps<30){
            points = (1-((temps/30)/2))*(diffi*100);
        }
        Console.WriteLine($"Résultat du calcul de point -> {points}");
        // Vous pouvez ajuster la formule pour contrôler la croissance des points en fonction du temps
        joueur.Scoreactuel = joueur.Scoreactuel + (diffi*points);
        Console.WriteLine($"Vous gagnez {(diffi*points).ToString("#.##")} points ! Difficulté {DifficulteQuestion}\nVotre total de points est maintenant de {joueur.Scoreactuel.ToString("#.##")}\nAppuyer sur une touche pour continuer !");
    }
}