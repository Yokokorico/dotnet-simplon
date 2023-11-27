using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Program{
    

    static void Main(string []args){
        List<QuestionJson> source = new List<QuestionJson>();
        bool gameover=false;
        string line = "0";
        string test1= "1";
        string test2= "2";
        string sep = "\n--------------------------------------------------\n";
        Console.WriteLine(sep +"Bienvenue sur CodeMaster Quiz \n\n1. Pour démarrer \n2. Quitter\n\n Votre réponse ->");
        source = RecupJsonQuestion("../../../question.json");
        line = Console.ReadLine();
        if (line == "1"){
            Console.WriteLine("CA DEMARRE"+sep);

            Console.WriteLine("1.Question aléatoire !\n2.Choix de la catégorie\n3.Quitter");
            /*
                TODO
            */

        }else if (line == "2"){
            Console.WriteLine("CA QUITTE");
        }else {
            Console.WriteLine("CA recommence");
        }
    }
    
    public static List<QuestionJson> RecupJsonQuestion(string pathfile){
        using (StreamReader r = new StreamReader(pathfile))  
        {  
            string json = r.ReadToEnd();  
            List<QuestionJson>output = JsonSerializer.Deserialize<List<QuestionJson>>(json);
            return output;
        } 
    }
}






// line= Console.ReadLine();

// while(gameover ==false){
//     if(line.Equals(test1)) {
//         var incomming = new List<QuestionJson>();
//         using (StreamReader r = new StreamReader("C:/Users/yokod/Documents/Simplon/.Net/Projet/CodeMasterQuiz/question.json")){
//             string json = r.ReadToEnd();
//             incomming = JsonSerializer.Deserialize<List<QuestionJson>>(json);
//         }

//         if ( incomming != null && incomming.Count > 0){
//             foreach(var question in incomming){
//                 Console.WriteLine($"{question.Question} {question.Reponse1}");
//             }
//         }
//     }else if(line.Equals(test2)) {
//         Console.WriteLine(sep +"Au revoir !"+sep);
//         gameover = true;
//     }else{
//         Console.WriteLine(sep+"\n Merci de bien répondre par 1 ou 2");
//         Console.WriteLine("\n\n1. Pour démarrer \n2. Quitter\n\n Votre réponse ->");
//         line= Console.ReadLine();
//     }
// }


// public record struct QuestionJson(
//     string Question,
//     string Reponse1,
//     string Reponse2,
//     string Reponse3,
//     string Reponse4,
//     int resultat,
//     int difficulte

// );
// // public class JSONQuestion{
// //     public string Question {get; set; }
// //     public string Categorie {get; set; }

// //     public string Reponse1 {get; set; }
// //     public string Reponse2 {get; set; }
// //     public string Reponse3 {get; set; }
// //     public string Reponse4 {get; set; }
// //     public int resultat {get; set; }
// //     public int difficulte {get; set; }
// // }
