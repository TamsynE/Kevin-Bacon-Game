/*
* The Kevin Bacon Game
* Finds a path between any two actresses/actors by connecting them through common movies
* file: 2022_Spring_TamsynEvezard_KevinBaconGame.cs
* author: Tamsyn Evezard
*/


using System;
using System.IO;
using GraphProject;
using System.Collections.Generic;

namespace KevinBaconGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE KEVIN BACON GAME!");
            Console.WriteLine("------------------------------------------------------------------------------------");

            //1. Load the movie database from the IMDB file into a graph object
            string sourceFile = args[0];
            if(!File.Exists(sourceFile))
            {
                Console.WriteLine($"'{sourceFile}' cannot be found.");
                return;
            }

            string[] lines = File.ReadAllLines(sourceFile);
           
            MathGraph<string> graph = new MathGraph<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] vertices = lines[i].Split('|');
                string names = vertices[0];
                string movies = vertices[1];

                if(names.Contains(" ("))
                {
                    string[] newName = names.Split(' ');
                    names = newName[0] + ' ' + newName[1];
                }

                if(!graph.ContainsVertex(names))
                {
                    graph.AddVertex(names);
                }

                if(!graph.ContainsVertex(movies))
                {
                    graph.AddVertex(movies);
                }
                graph.AddEdge(names, movies);
            }

            //2. Read console input such as "Antonio Banderas and Audrey Hepburn"
            if(args.Length == 0) // nothing inputted
            {
                Console.WriteLine("Error: no arguments were inputted.");
                return;
            }

            else if (args.Length == 3) // filename, actor 1, actor 2
            {
                string filename = args[0];
                string actor1 = args[1];
                string actor2 = args[2];

                if(!File.Exists(filename)) // check file exists
                {
                    Console.WriteLine($"Error: '{filename}' does not exist.");
                    return;
                }

                if(!graph.ContainsVertex(actor1)) // check actor 1 exists
                {
                    Console.WriteLine($"Actor '{actor1}' not found.");
                    return;
                }

                if (!graph.ContainsVertex(actor2)) // check actor 2 exists
                {
                    Console.WriteLine($"Actor '{actor2}' not found.");
                    return;
                }

                //5. Find the shortest path from one actor/ actress to the other
                List<string> results = graph.FindShortestPath(actor1, actor2);

                //6. Calculate the degrees of separation score
                int degree = (results.Count - 1) / 2;
                Console.WriteLine("*** results ***");
                Console.WriteLine($"INTERESTING FACT: {actor1} has been in {graph.CountAdjacent(actor1)} movie(s) and {actor2} has been in {graph.CountAdjacent(actor2)} movie(s).");
                Console.WriteLine($"The degree of separation between {actor1} and {actor2} is {degree}.");
                Console.WriteLine("SHORTEST PATH:");

                //7. Display the path from one person to the other
                for (int j = 0; j < results.Count - 2; j += 2)
                {
                    Console.WriteLine($"{results[j]} was in {results[j + 1]} with {results[j + 2]}.");
                }

                while (true)
                {
                    Console.Write(">");
                    string inputActors = Console.ReadLine();
                    if (inputActors.Length == 4)
                    {
                        inputActors.ToLower();
                        if (inputActors == "quit" || inputActors == "exit")
                        {
                            return;
                        }
                    }

                    int a = inputActors.IndexOf(" and ");
                    actor1 = inputActors.Substring(0, a);
                    actor2 = inputActors.Substring(a + 5);

                    //3. Verify that each actress/ actor is valid
                    if (!graph.ContainsVertex(actor1))
                    {
                        Console.WriteLine($"Actor '{actor1}' not found.");
                        return;
                    }

                    if (!graph.ContainsVertex(actor1))
                    {
                        Console.WriteLine($"Actor '{actor2}' not found.");
                        return;
                    }

                    //4. Verify that the two people are connected
                    if (graph.TestConnectedTo(actor1, actor2) == false)
                    {
                        Console.WriteLine($"{actor1} and {actor2} are not connected.");
                        return;
                    }

                    else
                    {
                        //5. Find the shortest path from one actor/ actress to the other
                        results = graph.FindShortestPath(actor1, actor2);

                        //6. Calculate the degrees of separation score
                        degree = (results.Count - 1) / 2;
                        Console.WriteLine("*** results ***");
                        Console.WriteLine($"INTERESTING FACT: {actor1} has been in {graph.CountAdjacent(actor1)} movie(s) and {actor2} has been in {graph.CountAdjacent(actor2)} movie(s).");
                        Console.WriteLine($"The degree of separation between {actor1} and {actor2} is {degree}.");
                        Console.WriteLine("SHORTEST PATH:");

                        //7. Display the path from one person to the other
                        for (int j = 0; j < results.Count - 2; j += 2)
                        {
                            Console.WriteLine($"{results[j]} was in {results[j + 1]} with {results[j + 2]}.");
                        }
                    }
                }
            }
            else if(args.Length == 1) // only given filename
            {
                string filename = args[0];

                if (!File.Exists(filename)) // check file exists
                {
                    Console.WriteLine($"Error: {filename} does not exist.");
                    return;
                }


                Console.WriteLine("Please input your actors/actresses in the format: <Actor 1> and <Actor 2>:");

                while (true)
                {
                    Console.Write(">");
                    string inputActors = Console.ReadLine();
                    if (inputActors.Length == 4)
                    {
                        inputActors.ToLower();
                        if (inputActors == "quit" || inputActors == "exit")
                        {
                            return;
                        }
                    }
                    
                    int a = inputActors.IndexOf(" and ");
                    string actor1 = inputActors.Substring(0, a);
                    string actor2 = inputActors.Substring(a + 5);

                    //3. Verify that each actress/ actor is valid
                    if (!graph.ContainsVertex(actor1))
                    {
                        Console.WriteLine($"Actor '{actor1}' not found.");
                        return;
                    }

                    if (!graph.ContainsVertex(actor2))
                    {
                        Console.WriteLine($"Actor '{actor2}' not found.");
                        return;
                    }

                    //4. Verify that the two people are connected
                    if (graph.TestConnectedTo(actor1, actor2) == false)
                    {
                        Console.WriteLine($"{actor1} and {actor2} are not connected.");
                        return;
                    }

                    else
                    {
                        //5. Find the shortest path from one actor/ actress to the other
                        List<string> results = graph.FindShortestPath(actor1, actor2);

                        //6. Calculate the degrees of separation score
                        int degree = (results.Count - 1) / 2;

                        Console.WriteLine("*** results ***");
                        Console.WriteLine($"INTERESTING FACT: {actor1} has been in {graph.CountAdjacent(actor1)} movie(s) and {actor2} has been in {graph.CountAdjacent(actor2)} movie(s).");
                        Console.WriteLine($"The degree of separation between {actor1} and {actor2} is {degree}.");
                        Console.WriteLine("SHORTEST PATH:");

                        //7. Display the path from one person to the other
                        for (int j = 0; j < results.Count-2; j += 2)
                        {
                            Console.WriteLine($"{results[j]} was in {results[j+1]} with {results[j+2]}.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: too many arguments.");
                return;
            }
        }
    }
}