using System;
using System.Collections.Generic;

namespace TragicTheReckoning.Models
{
    public class Player
    {
        private const int ManaLimit = 5;
        public const int MaxCardsInHand = 6;
        public bool HasCardsInDeck => Deck.cardPool.Count > 0;
        
        public Deck Deck { get; private set; }
        public List<Card> Hand { get; private set; }
        public List<Card> CardsInArena { get; private set; }
        
        public string Name { get; private set; }
        public int HealthPoints { get; set; }
        private int _manaPoints = 0;
        public int ManaPoints
        {
            get => _manaPoints;
            set => _manaPoints = value >= Player.ManaLimit ? Player.ManaLimit : value;
        }
        
        public Player(string name)
        {
            Name = name;
            SetPlayerToDefault();
        }
        
        public void SetPlayerToDefault()
        {
            HealthPoints = 10;
            ManaPoints = 0;
            Deck = new Deck();
            Hand = new List<Card>();
            CardsInArena = new List<Card>();
            // GIVE THE PLAYER THE 6 INITIAL CARDS, THE DECK IS ALREADY SHUFFLED
            for (int i = 0; i < MaxCardsInHand; i++)
                BuyNewCard();
        }
        
        public void BuyNewCard()
        {
            Card c = Deck.cardPool[0];
            Hand.Add(c);
            Deck.cardPool.Remove(c);
            
            if(!HasCardsInDeck)
            {
                Console.WriteLine();
                Console.WriteLine("The deck has run out of cards!");
                throw new Exception();
            }
        }

        public bool TrySendCartFromHandToArena(Card card)
        {
            Card pickedCard = null;
            
            foreach (Card cardInHand in Hand)
                if (cardInHand == card)
                    pickedCard = cardInHand;
            
            if (pickedCard == null)
                throw new Exception("tried to move from hand to battle arena a card that doesn't exist");

            if (card.Cost > ManaPoints) 
                return false;
            
            CardsInArena.Insert(0, pickedCard);
            Hand.Remove(pickedCard);
            ManaPoints -= card.Cost;
            return true;
        }
        
        public override string ToString() => $"{Name} (HP: {HealthPoints}) (MP: {ManaPoints})";
    }
}