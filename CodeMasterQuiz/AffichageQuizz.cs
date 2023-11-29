namespace Classes;

public class AffichageQuizz{
    const string sep = "\n\n--------------------------------------------------\n\n";
    const string filepath ="../../../question.json";
    /// <summary>
    /// Méthode de lancement du quizz
    /// </summary>
    /// <param name="joueur">Joueur actuel</param>
    /// <param name="choix">Boolean disant si l'utilisateur dois choisir sa catégorie</param>
    public static void DebutQuizz(Joueur joueur,bool choix){

        Random rand = new Random();
        List<Root>  source = new List<Root>();
        int index=1;
        bool verif=false;
        source = RecupJson.RecupJsonQuestion(filepath) ?? new List<Root>();
        joueur.Scoreactuel = 0;
        if(choix){
            Console.WriteLine("Veuillez choisir votre catégorie "+joueur.Nom +sep);
            foreach(Root items in source){
                Console.WriteLine(index+"."+items.Quizz[0].Category);
                index++;
            }
            while(verif==false){
                Console.WriteLine(sep+"Votre choix ->");
                int num_quizz = Int32.Parse(Console.ReadLine() ?? "0")-1;
                if(num_quizz <= source.Count && num_quizz > 0){
                    for(int index_question = 0;index_question<10;index_question++){
                        int numquestion = rand.Next(source[num_quizz].Quizz[0].Questions.Count);
                        AffichageQuestion(num_quizz,numquestion,source,joueur);
                    }
                    verif=true;
                }else{
                    Console.WriteLine("Merci de bien renseigner un choix correct !");
                }
            }
            Console.WriteLine("Felicitation vous avez obtenu "+joueur.Scoreactuel+" points !");
            joueur.Highscore=joueur.Scoreactuel;
            joueur.Scoreactuel=0;
        }else{
            for(int index_question = 0;index_question<10;index_question++){
                int numroot = rand.Next(source.Count);
                int numquestion = rand.Next(source[numroot].Quizz[0].Questions.Count);
                AffichageQuestion(numroot,numquestion,source,joueur);
            }
            Console.WriteLine("Felicitation vous avez obtenu "+joueur.Scoreactuel+" points !");
            joueur.Highscore=joueur.Scoreactuel;
            joueur.Scoreactuel=0;
        }  
    }
    /// <summary>
    /// Méthode affichage d'une question
    /// </summary>
    /// <param name="numroot">Numéro de quizz</param>
    /// <param name="numquestion">Numéro de question</param>
    /// <param name="source">Fichier json</param>
    /// <param name="joueur">Joueur actuel</param>
    public static void AffichageQuestion(int numroot,int numquestion,List<Root>  source,Joueur joueur){
        bool verif=false;
        string IntituleQuestion=source[numroot].Quizz[0].Questions[numquestion].IntituleQuestion ?? "";
        string DifficulteQuestion=source[numroot].Quizz[0].Questions[numquestion].Resultat[2].Difficulte.ToString();
        string DescriptifQuestion = source[numroot].Quizz[0].Questions[numquestion].Resultat[1].Descriptif;
        Console.WriteLine(sep+IntituleQuestion+"\nQuestion de difficulté "+DifficulteQuestion+"\nVous avez actuellement "+joueur.Scoreactuel+" points !");
        foreach (Reponse item in source[numroot].Quizz[0].Questions[numquestion].Reponses)
        {
            Console.WriteLine(item.Index.ToString()+". "+item.InitituleReponse);
        }
        while(verif==false){
            Console.WriteLine("Entrer votre réponse ->");
            string rep = Console.ReadLine() ?? "";
            if(rep == "1" ||rep == "2" ||rep == "3" ||rep == "4"){
                verif=true;
                if(Int32.Parse(rep) == source[numroot].Quizz[0].Questions[numquestion].Resultat[0].Reponse){
                    Console.WriteLine("Bien joué !");
                    Console.WriteLine(DescriptifQuestion ?? "");
                    Console.WriteLine("Vous gagnez "+DifficulteQuestion+" points ! (Difficulté "+DifficulteQuestion+")");
                    joueur.Scoreactuel =  source[numroot].Quizz[0].Questions[numquestion].Resultat[2].Difficulte + joueur.Scoreactuel;
                    Thread.Sleep(2000);                   
                } else {
                    Console.WriteLine("Mauvaise réponse !");
                    Console.WriteLine(DescriptifQuestion ?? "");
                    Thread.Sleep(2000);
                }
            }else{
                Console.WriteLine("Merci de bien vouloir répondre par 1,2,3 ou 4 !");
            }
        }
    }
} 