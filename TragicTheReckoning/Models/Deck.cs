using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TragicTheReckoning
{
    public class Deck
    {
        public List<Card> Pool { get; private set; }
        public List<Card> Hand { get; private set; } = new List<Card>()
        {
            new Card("bilu bilu",2,1,3),
            new Card("ahahah",3,1,3),
            new Card("nheco nehco",3,4,1)
        };

        public void Shuffle()
        {
            Pool.Sort();
        }
    }
}