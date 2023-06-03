using System;
using System.Collections.Generic;
using TragicTheReckoning.Controllers;

namespace TragicTheReckoning
{
    public class Player
    {
        public string Name { get; private set; }
        public int ManaPoints { get; private set; }
        public int HealthPoints { get; private set; }
        public Deck Deck { get; private set; }
       
        public List<Card> Hand { get; private set; } = new List<Card>();
        
        public Player(string name, int manaPoints, int healthPoints)
        {
            Name = name;
            ManaPoints = manaPoints;
            HealthPoints = healthPoints;
            Deck = new Deck();
            for (int i = 0; i < 6; i++)
            {
                Buy();
            }
        }
        
        public void Buy()
        {
            Card c = Deck.cardPool[Deck.cardPool.Count - 1];
            Hand.Add(c);
            Deck.cardPool.Remove(c);
        }
        
        
        //PRECISO DE UMA REFERÊNCIA AO GAMELOOP DENTRO DO BUY FINALIZADO
        //PARA PODER CHAMAR O GETWINNER CASO O JOGADOR DÊ DRAW À ULTIMA CARTA
        //COM O CÓDIGO ABAIXO

        //if(cardPool.Length <= 0)
        //{
        //    GameLoop.GetWinner();
        //}
    }
}