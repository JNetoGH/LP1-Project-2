using System;

namespace TragicTheReckoning
{
    public class Card
    {
        private Random rnd = new Random();
        
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int AttackPoints { get; private set; }
        public int DefencePoints { get; private set; }

        public Card(string name, int cost, int attackPoints, int defencePoints)
        {
            Name = name;
            Cost = cost;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
        }

        public int CompareTo(Card other)
        {
            return rnd.Next(0, 2);
        }
    }
}