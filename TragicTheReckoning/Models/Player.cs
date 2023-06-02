using System;

namespace TragicTheReckoning
{
    public class Player
    {
        public string Name { get; private set; }
        public int ManaPoints { get; private set; }
        public int HealthPoints { get; private set; }
        public Deck Deck { get; private set; }

        public Player(string name, int manaPoints, int healthPoints)
        {
            Name = name;
            ManaPoints = manaPoints;
            HealthPoints = healthPoints;
            Deck = new Deck();
        }
        
        public void Buy()
        {
            Deck.Hand.Add(Deck.shuffledDeck[0]);
            Deck.shuffledDeck.RemoveAt(0);
        }
    }
}