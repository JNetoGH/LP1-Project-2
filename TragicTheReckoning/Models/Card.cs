namespace TragicTheReckoning.Models
{
    public class Card
    {   
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int maxAttackPoints { get; private set; }
        public int currentAttackPoints { get; set; }
        public int maxDefencePoints { get; private set; }
        public int currentDefencePoints { get; set; }

        public Card(string name, int cost, int attackPoints, int defencePoints)
        {
            Name = name;
            Cost = cost;
            maxAttackPoints = attackPoints;
            maxDefencePoints = defencePoints;
        }

        public override string ToString()
        {
            return $"{Name} (Cost:{Cost}) (AP:{maxAttackPoints}) (DP:{maxDefencePoints})";
        }
        
    }
}