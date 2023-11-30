using System.Diagnostics;

namespace Classes;

public class AffichageQuizz
{
    const string sep = "\n\n--------------------------------------------------\n\n";
    const string filepath = "../../../question.json";
    /// <summary>
    /// Méthode de lancement du quizz
    /// </summary>
    /// <param name="joueur">Joueur actuel</param>
    /// <param name="choix">Boolean disant si l'utilisateur dois choisir sa catégorie</param>
    public static void DebutQuizz(Joueur joueur, bool choix)
    {

        Random rand = new Random();
        List<racineJson> source = new List<racineJson>();
        int index = 1;
        source = RecupJson.RecupJsonQuestion(filepath) ?? new List<racineJson>();
        joueur.Scoreactuel = 0;
        if (choix)
        {
            Console.WriteLine($"Veuillez choisir votre catégorie {joueur.Nom}{sep}");
            foreach (racineJson itemRoot in source)
            {
                Console.WriteLine(index + "." + itemRoot.Quizz[0].Category);
                index++;
            }
            AfficherQuestionsSiCategorie(joueur, source);
            AffichageFinDeQuizz(joueur);
        }
        else
        {
            for (int index_question = 0; index_question < 10; index_question++)
            {
                int numroot = rand.Next(source.Count);
                int numquestion = rand.Next(source[numroot].Quizz[0].Questions.Count);
                AffichageQuestion(numroot, numquestion, source, joueur, index_question);
            }
            AffichageFinDeQuizz(joueur);
        }
    }

    private static void AffichageFinDeQuizz(Joueur joueur)
    {
        Console.WriteLine($"Felicitation vous avez obtenu {joueur.Scoreactuel.ToString("#.##")} points !\nAppuyer sur une touche pour continuer !");
        Console.ReadLine();
        Console.Clear();
        joueur.Highscore = joueur.Scoreactuel;
        joueur.Scoreactuel = 0;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="joueur"></param>
    /// <param name="rand"></param>
    /// <param name="source"></param>
    private static void AfficherQuestionsSiCategorie(Joueur joueur, List<racineJson> source)
    {
        Random rand = new Random();
        var verificationBonchoix = false;
        while (!verificationBonchoix)
        {
            Console.WriteLine($"{sep}Votre choix ->");
            Int32.TryParse(Console.ReadLine(),out int num_quizz);
            if (num_quizz <= source.Count && num_quizz > 0)
            {
                for (int index_question = 0; index_question < 10; index_question++)
                {
                    int numquestion = rand.Next(source[num_quizz-1].Quizz[0].Questions.Count);
                    Console.WriteLine(source[num_quizz-1].Quizz[0].Questions.Count);
                    Console.Clear();
                    AffichageQuestion(num_quizz-1, numquestion, source, joueur, index_question);
                }
                verificationBonchoix = true;
            }
            else
            {
                Console.WriteLine("Merci de bien renseigner un choix correct !");
            }
        }
    }
    /// <summary>
    /// Méthode affichage d'une question
    /// </summary>
    /// <param name="numroot">Numéro de quizz</param>
    /// <param name="numquestion">Numéro de question</param>
    /// <param name="source">Fichier json</param>
    /// <param name="joueur">Joueur actuel</param>
    public static void AffichageQuestion(int numroot, int numquestion, List<racineJson> source, Joueur joueur, int index_question)
    {
        bool verif = false;
        string IntituleQuestion = source[numroot].Quizz[0].Questions[numquestion].IntituleQuestion ?? "";
        string DifficulteQuestion = source[numroot].Quizz[0].Questions[numquestion].Resultat[2].Difficulte.ToString();
        string DescriptifQuestion = source[numroot].Quizz[0].Questions[numquestion].Resultat[1].Descriptif;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"{sep}Question numéro {index_question+1}\nQuestion de difficulté {DifficulteQuestion}\nVous avez actuellement {joueur.Scoreactuel.ToString("#.##")} points !\n\n{IntituleQuestion}\n");
        foreach (Reponse item in source[numroot].Quizz[0].Questions[numquestion].Reponses)
        {
            Console.WriteLine(item.Index.ToString() + ". " + item.InitituleReponse);
        }
        while (!verif)
        {
            Console.WriteLine("Entrer votre réponse ->");
            string rep = Console.ReadLine() ?? "";
            if (rep == "1" || rep == "2" || rep == "3" || rep == "4")
            {
                verif = true;
                CalculPoint.CalculDesPoints(numroot, numquestion, source, joueur, DifficulteQuestion, DescriptifQuestion, stopwatch, rep);
            }
            else
            {
                Console.WriteLine("Merci de bien vouloir répondre par 1,2,3 ou 4 !");
            }
        }
    }
}