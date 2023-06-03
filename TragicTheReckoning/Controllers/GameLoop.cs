﻿using System;
using TragicTheReckoning.Controllers.Phases;


namespace TragicTheReckoning.Controllers
{
    public class GameLoop
    {
        private const int ManaLimit = 6;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly SpellPhase _spellPhase;
        private readonly BattlePhase _battlePhase;

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
            
            int counter = 1;
            // Game Loop
            do
            {
                _player1.ManaPoints = counter >= ManaLimit ? ManaLimit : counter;
                _player2.ManaPoints = counter >= ManaLimit ? ManaLimit : counter;
                _spellPhase.RunPhase(_player1, _player2);
                _battlePhase.RunPhase(_player1, _player2);
                counter++;
            } while (TryGetWinner() is null);
            
            // greeting msg
        }
        
        private void InitGame(params Player[] players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine("Initializing game ...");
            }
        }

        private Player TryGetWinner()
        {
            if (_player2.HealthPoints <= 0)
                return _player1;
            if (_player1.HealthPoints <= 0)
                return _player2;
            return null;
        }
        
    }
}