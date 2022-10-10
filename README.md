# Kevin-Bacon-Game #

There is a popular party game called the the Six Degrees of Kevin Bacon. The purpose of the game is to find a path from any actress/actor to Kevin Bacon by connecting them through common movies. For example, Meryl Streep was in The River Wild with Kevin Bacon, so she has a Bacon Number of 1. Harrison Ford has a Bacon Number of 2 because you can connect them through two movies: Harrison Ford --> Laurence Fishburne (Apocalypse Now) and then Laurence Fishburne --> Kevin Bacon (Mystic River). If you're into movies, this is a fun game that allows you to demonstrate your superior Hollywood trivia knowledge. And more information can be found on Wikipedia.

There are many possible paths connecting any two people, but the "Bacon Number" is supposed to be the shortest path. So if your friend can find a path that takes 5 different movies, but you can find one that only takes 4, then you have won. Woohoo! Note that for many actors and actresses, there are multiple minimum paths that are all considered winners.

This program goes beyond Kevin Bacon and provides an authoritative path between any two actors based on the IMDB database. To do this, I created a graph from a recent pull of the Internet Movie Database (IMDB) and then use a provided graph library to find the shortest path between any two actresses.

The program performs the following actions:

1) Loads the movie database from the IMDB fiel into a graph object
2) Reads console input such as "Antonio Banderas and Audrey Hepburn"
3) Verifies that each actress/actor is valid
4) Verifies that the two people are connected
5) Finds the shortest path from one actor/actress to the other using Djikstra's Algorithm
6) Calculates the degrees of separation score
7) Displays the path from one person to the other
8) Loops back to step #2 until the user types "quit" or "exit"

Command Line Parameters / Input Loop:

The program requires at least one parameter in order to run. This parameter is the path\name of the IMDB file to load. The user is allowed to enter two additional parameters that correspond to the names of two actors/actresses. These parameters will need to include the first and last name, which means they'll each need to be enclosed in quotes.

If the two actors/actresses are not provided in the command line parameters, then the program enters a very basic loop that repeatedly asks the user to enter two names. It then runs the Kevin Bacon Game with those two names.
