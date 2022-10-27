using System;
using PokemonApp;

namespace Program{

    class Program{

        static void Main(string[] args)
        {
            //Initializing an object
            //We call the constructor, and pass it the desired values for this object
            //Pokemon pikachu = new Pokemon("Pikachu", 25, "Electric", 12, "Static");
            //Pokemon pikachu2 = new Pokemon("Pikachu", 25, "Electric", 12);

            Pokemon charizard = new Pokemon("Charmander", 4, "Fire", 35, "Blaze");
            Pokemon charmander = new Pokemon("Charmander", 4, "Fire", 35, "Blaze");

            Console.WriteLine(charmander.Battle(charizard));
            
            //Calling an Instance method - belongs to the object itself.
            //Called by using object.method() 
            //pikachu.PrintName();
            //pikachu2.PrintName();
            Console.WriteLine(charizard.ToString());
            //Calling a Static method - belongs to the class.
            //Called by using Class.method()
            //Pokemon.PrintMessage();
            //Accessing a Static field - belongs to the class.
            //Called by referencing the class itself.
            //Console.WriteLine(Pokemon.isPokemon);
            //Console.WriteLine(pikachu.ToString());
            //Console.WriteLine(pikachu.name);

            charizard.Evolve("Charmeleon", 5, "Fire", 70, "Blaze");
            Console.WriteLine(charmander.Battle(charizard));
            Console.WriteLine(charizard.ToString());
            charizard.Evolve("Charizard", 6, "Fire and Flying", 150, "Blaze");
            Console.WriteLine(charmander.Battle(charizard));
            
            Console.WriteLine(charizard.ToString());
        }
        

    }

}