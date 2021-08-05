using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

        static void MeatEaterOrHerbivore()
        {
            var carnivores = new List<string>();
            var herbivores = new List<string>();
        }

    }
    class Program
    {
        private static void Description(DateTime WhenAcquired, Dinosaur foundDinosaur)
        {
            Console.WriteLine($"{foundDinosaur.Name} weighs {foundDinosaur.Weight} pounds.");
            Console.WriteLine($"{foundDinosaur.Name} is a {foundDinosaur.DietType}.");
            Console.WriteLine($"{foundDinosaur.Name} is in enclosure {foundDinosaur.EnclosureNumber}.");
            Console.WriteLine($"{foundDinosaur.Name} was acquired on {WhenAcquired}");
            Console.WriteLine();
        }

        private static void IfNoDinosaurs(List<Dinosaur> dinoList)
        {
            if (dinoList.Count == 0)
            {
                Console.WriteLine("There are 0 dinosaurs in the park!");
            }
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();

            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that was not a valid weight. I'm going to use 0 as the weight.");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            DateTime WhenAcquired = DateTime.Now;
            var dinoList = new List<Dinosaur>();
            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("Would you like to:\n(V)iew a dinosaur\n(A)dd a dinosaur\n(R)emove a dinosaur\n(T)ransfer a dinosaur\n(S)ummary of a dinosaur\n(Q)uit program\n");
                var choice = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (choice == "Q")
                {
                    keepGoing = false;
                }
                else
                if (choice == "V")
                {
                    Console.WriteLine("Viewing dinosaurs:");
                    Console.WriteLine();
                    foreach (var dinosaur in dinoList)
                    {
                        Console.WriteLine($"{dinosaur.Name} weighs {dinosaur.Weight} pounds.");
                        Console.WriteLine($"{dinosaur.Name} is a {dinosaur.DietType}.");
                        Console.WriteLine($"{dinosaur.Name} is in enclosure {dinosaur.EnclosureNumber}.");
                        Console.WriteLine($"{dinosaur.Name} was acquired on {WhenAcquired}");
                        Console.WriteLine();
                    }
                    IfNoDinosaurs(dinoList);
                }
                else
                if (choice == "A")
                {
                    Console.WriteLine("Adding dinosaur");
                    Console.WriteLine();

                    var dinosaur = new Dinosaur();

                    dinosaur.Name = PromptForString("What is the dinosaur's name? ");
                    dinosaur.DietType = PromptForString("What is the dinosaur's diet type? Carnivore or herbivore? ");
                    dinosaur.Weight = PromptForInteger("How much does the dinosaur weigh in pounds? ");
                    dinosaur.EnclosureNumber = PromptForInteger("What enclosure will this dinosaur be kept in? ");

                    dinoList.Add(dinosaur);
                }
                else
                if (choice == "R")
                {
                    Console.WriteLine("Removing dinosaur:");
                    Console.WriteLine();

                    IfNoDinosaurs(dinoList);

                    var dinoToSearchFor = PromptForString("Which dinosaur do you want to remove? ");

                    Dinosaur foundDinosaur = dinoList.FirstOrDefault(dinosaur => dinosaur.Name == dinoToSearchFor);
                    if (foundDinosaur == null)
                    {
                        Console.WriteLine("No dinosaur by that name is in this park!");
                    }
                    else
                    {
                        Description(WhenAcquired, foundDinosaur);

                        var confirm = PromptForString($"Are you sure you want to remove {foundDinosaur.Name}? [Y/N] ").ToUpper();

                        if (confirm == "Y")
                        {
                            dinoList.Remove(foundDinosaur);
                        }
                    }



                }
                else
                if (choice == "T")
                {
                    Console.WriteLine("Transferring dinosaur");
                    Console.WriteLine();

                    IfNoDinosaurs(dinoList);

                    var dinoToSearchFor = PromptForString("Which dinosaur do you want to transfer? ");

                    Dinosaur foundDinosaur = dinoList.FirstOrDefault(dinosaur => dinosaur.Name == dinoToSearchFor);

                    if (foundDinosaur == null)
                    {
                        Console.WriteLine("No dinosaur by that name is in this park!");
                    }
                    else
                    {
                        Description(WhenAcquired, foundDinosaur);
                        foundDinosaur.EnclosureNumber = PromptForInteger($"What enclosure do you want to move {foundDinosaur.Name} to? ");

                        Console.WriteLine($"{foundDinosaur.Name} was moved to {foundDinosaur.EnclosureNumber}");
                    }
                }
                else
                if (choice == "S")
                {
                    Console.WriteLine("Summary of dinosaur");
                }
                else
                {
                    Console.WriteLine("Ah, ah ah, you didn't say the magic word");
                }
            }
        }


    }
}

