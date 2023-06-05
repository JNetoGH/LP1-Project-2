namespace TragicTheReckoning.Models
{
    public class Card
    {   
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int maxAttackPoints { get; private set; }
        public int currentAttackPoints { get; set; }
        public int DefencePoints { get; set; }

        public Card(string name, int cost, int attackPoints, int defencePoints)
        {
            Name = name;
            Cost = cost;
            maxAttackPoints = attackPoints;
            DefencePoints = defencePoints;
        }

        public override string ToString()
        {
            return $"{Name} (Cost:{Cost}) (AP:{maxAttackPoints}) (DP:{DefencePoints})";
        }
        
    }
}