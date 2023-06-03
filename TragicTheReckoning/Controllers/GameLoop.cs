using System;
using TragicTheReckoning.Controllers.Phases;


namespace TragicTheReckoning.Controllers
{
    public class GameLoop
    {
        private readonly Player _player1;
        private readonly Player _player2;
        
        private readonly BuyingPhase _buyingPhase;
        private readonly SpellPhase _spellPhase;
        private readonly BattlePhase _battlePhase;

        public GameLoop(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _buyingPhase = new BuyingPhase();
            _spellPhase = new SpellPhase();
            _battlePhase = new BattlePhase(player1, player2);
        }
        
        public void Run()
        {

            Player winner = null;
            InitGame(_player1, _player2);
            
            // Game Loop
            int counter = 1;
            do
            {
                _player1.ManaPoints = counter;
                _player2.ManaPoints = counter;
                _buyingPhase.RunPhase(_player1, _player2);
                _spellPhase.RunPhase(_player1, _player2);
                _battlePhase.RunPhase(_player1, _player2);
                counter++;
                winner = TryGetWinner();
                
            } while (winner == null);
            
            // greeting msg
        }

        private void InitGame(params Player[] players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine("Initializing game ...");
            }
        }

        // RETORNA O VENCEDOR, ENQUANTO NAO HOUVER RERTONA NULL
        private Player TryGetWinner()
        {
            _player1.HealthPoints = -133;
            if (_player2.HealthPoints <= 0) return _player1;
            if (_player1.HealthPoints <= 0) return _player2;
            return null;
        }
        
    }
}