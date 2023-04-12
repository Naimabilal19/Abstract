using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    interface iContinent
    {
        iHerbivoreAnimal CreateHerbivoreAnimal();
        iPredatorAnimal CreatePredatorAnimal();
    }
    class Africa : iContinent
    {
        public iHerbivoreAnimal CreateHerbivoreAnimal()
        {
            return new Wildebeest();
        }
        public iPredatorAnimal CreatePredatorAnimal()
        {
            return new Lion();
        }
    }
    class NorthAmerica : iContinent
    {
        public iHerbivoreAnimal CreateHerbivoreAnimal()
        {
            return new Bison();
        }
        public iPredatorAnimal CreatePredatorAnimal()
        {
            return new Wolf();
        }
    }

    interface iHerbivoreAnimal
    {
        string EatGrass();
        int ShowWeight();
    }
    class Wildebeest : iHerbivoreAnimal
    {
        private int Weight { get; set; }
        private bool IsAlive { get; set; }
        public string EatGrass()
        {
            Weight += 10;
            return "Wildebeest eat grass";
        }
        public int ShowWeight()
        {
            if (Weight > 0) IsAlive = true;
            else IsAlive = false;
            return Weight;
        }
    }
    class Bison : iHerbivoreAnimal
    {
        private int Weight { get; set; }
        private bool IsAlive { get; set; }
        public string EatGrass()
        {
            Weight += 10;
            return "Bison eat grass";
        }
        public int ShowWeight()
        {
            if (Weight > 0) IsAlive = true;
            else IsAlive = false;
            return Weight;
        }
    }

    interface iPredatorAnimal
    {
        string EatAnimal(iHerbivoreAnimal Animal);
        int ShowPower();
    }
    class Lion : iPredatorAnimal
    {
        private int Power { get; set; }
        private bool IsAlive { get; set; }
        public string EatAnimal(iHerbivoreAnimal Animal)
        {
            if (ShowPower() > Animal.ShowWeight())
            {
                Power += 10;
                return "Lion kill animal";
            }
            else
            {
                Power -= 10;
                return "Lion's power not enough";
            }
        }
        public int ShowPower()
        {
            if (Power > 0) IsAlive = true;
            else IsAlive = false;
            return Power;
        }
    }
    class Wolf : iPredatorAnimal
    {
        private int Power { get; set; }
        private bool IsAlive { get; set; }
        public string EatAnimal(iHerbivoreAnimal Animal)
        {
            if (ShowPower() > Animal.ShowWeight())
            {
                Power += 10;
                return "Wolf kill animal";
            }
            else
            {
                Power -= 10;
                return "Wolf's power not enough";
            }
        }
        public int ShowPower()
        {
            if (Power > 0) IsAlive = true;
            else IsAlive = false;
            return Power;
        }
    }

    class AnimalWorld
    {
        public void HerbivoresStartEat(iContinent Continent)
        {
            var HA = Continent.CreateHerbivoreAnimal();
            Console.WriteLine(HA.EatGrass());
            Console.WriteLine(HA.ShowWeight());
        }
        public void PredatorsStartHunt(iContinent Continent)
        {
            var HA = Continent.CreateHerbivoreAnimal();
            var PA = Continent.CreatePredatorAnimal();
            Console.WriteLine(PA.EatAnimal(HA));
            Console.WriteLine(PA.ShowPower());
        }
    }
    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new Africa());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new NorthAmerica());
        }

        public void ClientMethod(iContinent factory)
        {
            var productA = factory.CreateHerbivoreAnimal();
            var productB = factory.CreatePredatorAnimal();

            Console.WriteLine(productB.ShowPower());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
