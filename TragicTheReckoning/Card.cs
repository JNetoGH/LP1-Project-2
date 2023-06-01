namespace TragicTheReckoning
{
    public class Card
    {
        
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
    }
}