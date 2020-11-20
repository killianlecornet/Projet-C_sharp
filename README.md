# Projet-C_sharp (sous-titre)

Le projet marche seulement si certaines conditions sont respectées s'il y a 2 lignes dans le srt le code ne marchera pas ex:

(1								)
(00:00:00,000 --> 00:00:02,000	)
(coucou							)
(ça va 							)

Pour modifier le chemin dans le MainWindow.xaml c'est à la ligne 14.
et dans le MainWindow.xaml.cs c'est à la ligne 66 et 67.


Le système de temps marche avec un delai je récupère le temps au début et à la fin de chaque ligne de temps, j'enleve les caractères spéciaux puis je transforme le string en int pour faire après une soustraction avec le temps pour obtenir le delai tout cela sa passe dans une boucle.

Pour lancer la vidéo on doit faire play puis appuyer sur le bouton Sous-titre pour que les deux s'affiche avec le bon temps on ne peut pas faire pause à la video lorsque les sous-titres sont activés.

Après je ne sais pas si c'est dans le code mais je suis allé dans les proprieter du Projet-C pour modifier le type de sortie en application console pour pouvoir avoir mon sous-titre dedans.