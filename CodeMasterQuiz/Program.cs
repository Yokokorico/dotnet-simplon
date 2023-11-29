namespace Classes;
public class Program{
    const string def= " ";
    static void Main(string []args){
        Console.WriteLine("Tout d'abord quel est votre nom ?");
        string nom = Console.ReadLine() ?? def;
        Joueur joueur= new Joueur();
        joueur.Nom=nom;
        Console.Clear();
        AffichageMenu.Demarrage(joueur);
    }
}
