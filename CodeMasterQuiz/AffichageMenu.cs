namespace Classes;

public class AffichageMenu{
    const string sep = "\n\n--------------------------------------------------\n\n";
    const string def= " ";
    /// <summary>
    /// Méthode lançant l'écran d'acceuil
    /// </summary>
    /// <param name="joueur">Joueur actuel</param>
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
    /// <param name="joueur">Joueur actuel</param>
    public static void MenuPrincipal(Joueur joueur){
        string line = "";
        bool attente = true;
        while (attente == true){
            Console.WriteLine(sep+"1.Question aléatoire !\n2.Choix de la catégorie\n3.Retour"+sep);
            Console.WriteLine("Votre réponse ->");
            line = Console.ReadLine() ?? def;
            if (line == "1"){
                attente= false;
                
                AffichageQuizz.DebutQuizz(joueur,false);
            }else if(line == "2"){
                attente=false;
                
                AffichageQuizz.DebutQuizz(joueur,true);
                
            }else if(line == "3"){
                Demarrage(joueur);
            }else{
                Console.WriteLine("Merci de bien renseigner un choix correct !");
            }
        }
    }
}