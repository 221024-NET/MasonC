using System;

namespace PokemonApp{

    class Pokemon{
        
        //Fields - by default they are Private. 
        public string name {get; set;}
        int DexNumber {get; set;}
        string type {get; set;}
        int health {get; set;}
        string ability {get; set;}
        Boolean isFinalEvol {get; set;} = false;

        //Static field - every pokemon shares this field and it's value
        public static string isPokemon = "This is a static field. We've been through this, I'm in fact a pokemon.";
        
        //Constructor - method used for object initialization. We pass it the values we want 
        //to set for the object we are creating.

        public Pokemon(string PokemonName, int PokemonNum, string PokemonType, int PokemonHealth, string PokemonAbility = "default?"){

            this.name = PokemonName;
            this.DexNumber = PokemonNum;
            this.type = PokemonType;
            this.health = PokemonHealth;
            this.ability = PokemonAbility;
        }


        public Pokemon(){

        }

        public Pokemon(string PokemonName){
            this.name = PokemonName;
            this.DexNumber = 12;
        }

        //Instance method - depends on the state of an instance of that class. Belongs to the object. 
        public void PrintName(){
            Console.WriteLine("My name is " + this.name + "." + " My number is " + this.DexNumber + ". My ability is " + this.ability);

        }

        //Static method - belongs to the class itself
        public static void PrintMessage(){
            Console.WriteLine("This is a static method, and I am a pokemon.");
        }

        //Method Overriding - ToString()
        public override string ToString(){
            return this.name + " " + this.DexNumber + " " + this.type + " " + this.health + " " + this.ability + " " + isFinalEvol;
        }

        public void Evolve(string PokemonName = "Null", int PokemonNum = 999999, string PokemonType = "Null", int PokemonHealth = 999999, string PokemonAbility = "Null"){
            
            //Evolves a pokemon to a higher level.
            //Sets all of the params to new states.
            this.name = PokemonName;
            this.DexNumber = PokemonNum;
            this.type = PokemonType;
            this.health = PokemonHealth;
            this.ability = PokemonAbility;

        }

        public void setBoolTrue(){
            isFinalEvol = true;
        }

        public void setBoolFalse(){
            isFinalEvol = false;
        }

        public string Battle(Pokemon poke1){
            if(poke1.health > health){
                return poke1.name + " is the winner!";
            } else if(health > poke1.health){
                return name + " is the winner!";
            } else {
                return "The Pokemon are equally matched. It is a tie!";
            }
        }
    }


}