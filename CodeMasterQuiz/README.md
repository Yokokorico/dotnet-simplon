# Récupérer le projet

Bienvenue, pour récupérer le projet il suffit de télécharger le zip du code sur github à l'adresse suivante (https://github.com/Yokokorico/dotnet-simplon) et de la dezip

# Lancer le projet 

Pour lancer le projet lancer un terminal aller dans le dossier CodeMasterQuiz->bin->Debug->net6.0 puis lancer le .exe

## Recupération depuis un fichier JSON
Utilisation de la méthode **RecupJsonQuestion()** pour récuperer les données dans le fichier JSON question.json
### Structure du fichier JSON
    
    "Quizz": [
        {
            "Category": "",
            "Questions": [
                {
                    "IntituleQuestion": "",
                    "Reponses": [
                        { "Index":1,"InitituleReponse": "" },
                        { "Index":2,"InitituleReponse": "" },
                        { "Index":3,"InitituleReponse": "" },
                        { "Index":4,"InitituleReponse": "" }
                    ],
                    "Resultat":[
                        {"Reponse" : 0},
                        {"Descriptif": ""},
                        {"Difficulte":0}
                    ]
                }
            ]
        }
    ]


## Affichage du ménu principale

Après avoir entrée son nom l'écran du menu de demarrage est affiché avec la méthode **Demarrage()**

### Quelle est la structure de ma liste de questions ?
 - **Les différents type de collection**

1. List<>
2. Dictionnary<>
3. string[]

Si on fait un tableau de string pour lister les intitulés, comment lier chaque question à ses réponses ?
Il est temps de construire des classes : une classe Question qui contient une liste de réponse.

## Demander la catégorie (dans un second temps) et filtrer la liste des questions

## Parcourir les questions (boucle)
Pour chacune d'entre elles
1. **Poser la question**

2. **Donner les réponses possibles**

3. **Vérifier si la réponse est bonne/mauvaise/une erreur**

4. **Informer l'utilisateur du résultat et afficher son score**

5. **Boucler**

## Afficher un message d'au revoir avec le score lorsque l'ensemble des questions ont été posées