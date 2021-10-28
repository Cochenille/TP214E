# Description

Travail pratique 2 du cours de Conception et Qualité Logicielle au Cégep Garneau.
Présenté à Laurent Drolet.

# Membres
Wylliam Arcand - Cédric Bouchard

# Bogues
1. Le navigateur est fourni un URI plutôt qu'un instance de classe PageCommandes.
2. La classe PageCommandes n'a pas le bon namespace.
3. La classe PageCommandes n'hérite pas de la classe Page, mais Window.
4. La classe PageCommandes nécessiterait d'accepter un DAL dans son constructeur pour avoir accès à la base de données.