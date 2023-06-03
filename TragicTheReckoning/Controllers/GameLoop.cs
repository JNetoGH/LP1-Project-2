using System;
using TragicTheReckoning.Controllers.Phases;


namespace TragicTheReckoning.Controllers
{
    public class GameLoop
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly SpellPhase _spellPhase;
        private readonly BattlePhase _battlePhase;

        public static bool gameLoop { set; get; } = true;

        public GameLoop(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _spellPhase = new SpellPhase(player1, player2);
            _battlePhase = new BattlePhase(player1, player2);
        }
        
        public void Run()
        {
            InitGame(_player1, _player2);
            
            // Game Loop
            do
            {
                _spellPhase.RunPhase(_player1, _player2);
                _battlePhase.RunPhase(_player1, _player2);
            } while (gameLoop == true);

            // greeting msg
        }
        
        private void InitGame(params Player[] players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine("Initializing players, not implemented yet");
            }
        }

        private Player GetWinner()
        {
            gameLoop = false;
            
            if (_player1.HealthPoints == _player2.HealthPoints)
            {
                //DRAW
                return null;
            }
            else if (_player1.HealthPoints < _player2.HealthPoints)
            {
                return _player2;
            }
            else
            {
                return _player1;
            }
        }
        
    }
}