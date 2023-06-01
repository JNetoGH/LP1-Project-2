using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TragicTheReckoning
{
    public class Deck
    {
        public List<Card> Pool { get; private set; }
        public List<Card> Hand { get; private set; }

        public void Shuffle()
        {
            Pool.Sort();
        }

        public void DrawCard()
        {
            Hand.Add(Pool[0]);
            Pool.RemoveAt(0);
        }
    }
}