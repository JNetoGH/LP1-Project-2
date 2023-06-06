using System;
using TragicTheReckoning.Controllers.Phases;
using TragicTheReckoning.Models;


namespace TragicTheReckoning.Controllers
{
    public class GameLoop
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly BuyingPhase _buyingPhase;
        private readonly SpellPhase _spellPhase;
        private readonly BattlePhase _battlePhase;
        private readonly EndPhase _endPhase;

        private bool _running = true;

        public GameLoop()
        {
            _player1 = new Player("The Mage");
            _player2 = new Player("The Wizard");
            _buyingPhase = new BuyingPhase();
            _spellPhase = new SpellPhase();
            _battlePhase = new BattlePhase(_player1, _player2);
            _endPhase = new EndPhase();
        }

        public void Run()
        {
            InitGame(_player1, _player2);

            // Game Loop
            int counter = 1;

            do
            {
                _player1.ManaPoints = counter;
                _player2.ManaPoints = counter;

                try
                {
                    _buyingPhase.RunPhase(counter, _player1, _player2);
                    _spellPhase.RunPhase(counter, _player1, _player2);
                    _battlePhase.RunPhase(counter, _player1, _player2);
                    counter++;
                }
                catch (Exception)
                {
                    _running = false;
                }
                
            } while (_running);

            _endPhase.RunPhase(GetWinner());
        }

        private void InitGame(params Player[] players)
        {
            foreach (Player player in players)
                player.SetPlayerToDefault();
        }

        private Player GetWinner()
        {
            if (_player1.HealthPoints == _player2.HealthPoints)
            {
                return null;
            }

            return (_player1.HealthPoints < _player2.HealthPoints) ? _player2 : _player1;
        }
    }
}