using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading;

public class Program{
    
    const string sep = "\n\n--------------------------------------------------\n\n";
    const string filepath ="../../../question.json";
    const string def= " ";
    static void Main(string []args){
        Console.WriteLine("Tout d'abord quel est votre nom ?");
        string nom = Console.ReadLine() ?? def;
        Joueur joueur= new Joueur();
        joueur.Nom=nom;
        Demarrage(joueur);
    }
    public static List<Root>? RecupJsonQuestion(string pathfile){
        try{
            using (StreamReader r = new StreamReader(pathfile))  
            {  
                string json = r.ReadToEnd();  
                List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(json) ?? new List<Root>();          
                return myDeserializedClass;
            } 
        }catch (Exception){
            Console.WriteLine("JSON non trouvé!");
            Console.ReadLine();
            return null;
        }
            
    }
    /// <summary>
    /// Méthode lançant l'écran d'acceuil
    /// </summary>
    /// <param name="joueur"></param>
    public static void Demarrage(Joueur joueur){
        string line = "";
        bool attente = true;
        while (attente == true){
            Console.WriteLine(sep +"Bienvenue sur CodeMaster Quiz "+joueur.Nom+" \n\n1. Pour démarrer \n2. Quitter\n"+"Votre meilleur score est de "+(joueur.Highscore ?? 0)+"\n\nVotre réponse ->");
            line = Console.ReadLine() ?? def ;
            if (line == "1"){
                MenuPrincipal(joueur);
            }else if (line == "2"){
                Console.WriteLine("Au revoir ! "+joueur.Nom);
                Environment.Exit(0);
            }else {
                Console.WriteLine("Merci de bien répondre par 1,2 ou 3");
            }
        }
    }
    /// <summary>
    /// Méthode lançant le menu principal
    /// </summary>
    /// <param name="joueur"></param>
    public static void MenuPrincipal(Joueur joueur){
        string line = "";
        bool attente = true;
        while (attente == true){
            Console.WriteLine(sep+"1.Question aléatoire !\n2.Choix de la catégorie\n3.Retour"+sep);
            Console.WriteLine("Votre réponse ->");
            line = Console.ReadLine() ?? def;
            if (line == "1"){
                attente= false;
                
                DebutQuizz(joueur,false);
            }else if(line == "2"){
                attente=false;
                
                DebutQuizz(joueur,true);
                
            }else if(line == "3"){
                Demarrage(joueur);
            }else{
                Console.WriteLine("Merci de bien renseigner un choix correct !");
            }
        }
    }
    /// <summary>
    /// Méthode de lancement du quizz
    /// </summary>
    /// <param name="joueur"></param>
    /// <param name="choix"></param>
    public static void DebutQuizz(Joueur joueur,bool choix){
        Random rand = new Random();
        List<Root>  source = new List<Root>();
        int index=1;
        bool verif=false;
        source = RecupJsonQuestion(filepath);
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
