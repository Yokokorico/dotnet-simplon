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

namespace Classes;
public class Program{
    const string def= " ";
    static void Main(string []args){
        Console.WriteLine("Tout d'abord quel est votre nom ?");
        string nom = Console.ReadLine() ?? def;
        Joueur joueur= new Joueur();
        joueur.Nom=nom;
        AffichageMenu.Demarrage(joueur);
    }
}
