using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


public class Program{
    
    const string sep = "\n\n--------------------------------------------------\n";
    const string filepath ="../../../question.json";
    bool gameover=false;

    static void Main(string []args){

        Demarrage();
    }
    
    public static List<Root> RecupJsonQuestion(string pathfile){
        using (StreamReader r = new StreamReader(pathfile))  
        {  
            string json = r.ReadToEnd();  
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(json);          
            return myDeserializedClass;
        } 
    }
    /*Demarrage ou fermeture de l'app */

    public static void Demarrage(){
        string line = "";
        bool attente = true;
        while (attente == true){
            Console.WriteLine(sep +"Bienvenue sur CodeMaster Quiz \n\n1. Pour démarrer \n2. Quitter\n\n Votre réponse ->");
            line = Console.ReadLine();
            if (line == "1"){
                MenuPrincipale();
            }else if (line == "2"){
                Console.WriteLine("Au revoir ! ");
                Environment.Exit(0);
            }else {
                Console.WriteLine("Merci de bien répondre par 1,2 ou 3");
            }
        }
    }

    /*Affichage du menu principale */
    public static void MenuPrincipale(){

        string line = "";
        bool attente = true;
        Console.WriteLine(sep+"CA DEMARRE"+sep);

        while (attente == true){
            Console.WriteLine("1.Question aléatoire !\n2.Choix de la catégorie\n3.Retour"+sep);
            Console.WriteLine("Votre réponse ->");

            line = Console.ReadLine();
            if (line == "1"){
                attente= false;
                Console.WriteLine("ETTTTT CEZZ PARTI !");
                DebutQuizz();

            }else if(line == "2"){
                attente=false;
                Console.WriteLine("ET CHOISIS BATARD");
                Environment.Exit(0);

            }else if(line == "3"){
                Demarrage();
            }
        }
    }
    public static void DebutQuizz(){

        Random rand = new Random();
        List<Root>  source = new List<Root>();
        source = RecupJsonQuestion(filepath);
        int numroot = rand.Next(source.Count);
        int numquizz = rand.Next(source[numroot].Quizz.Count);
        int numquestion = rand.Next(source[numroot].Quizz[numquizz].Questions.Count);

        // Console.WriteLine(source[numroot].Quizz[numquizz].Questions[numquestion].IntituleQuestion);
    }

    public static void AffichageQuestion(int numroot,int numquizz,int numquestion){
        
    }

    
}



