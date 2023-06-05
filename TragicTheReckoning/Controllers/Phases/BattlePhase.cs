using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BattlePhase: IPhase
    {
        private readonly BattleView _battleView;
        private Player _player1;
        private Player _player2;
        
        public BattlePhase(Player player1, Player player2)
        {
            _battleView = new BattleView();
            _player1 = player1;
            _player2 = player2;
        }
        
        public void RunPhase(int roundNumber, params Player[] players)
        {
            _battleView.RenderPhaseLabel(roundNumber, this.GetType());
            BattlePhaseLoop(players);
            _battleView.RenderBattleView(players);
            
            _battleView.RenderPhaseExit(this.GetType());
        }

        public void BattlePhaseLoop(Player[] players)
        {
            foreach (Player player in players)
            {
                foreach (Card card in player.CardsInArena)
                {
                    card.currentAttackPoints = card.maxAttackPoints;
                }   
            }
            
            while (_player1.CardsInArena.Count > 0 & _player2.CardsInArena.Count > 0)
            {
                Card player1Card = _player1.CardsInArena[0];
                Card player2Card = _player2.CardsInArena[0];
                
                if (_player1.CardsInArena[0].currentAttackPoints <= 0 & 
                    _player2.CardsInArena[0].currentAttackPoints <= 0)
                {
                    break;
                }

                if (player1Card.DefencePoints > 0 & player2Card.DefencePoints > 0)
                {
                    int p1AttackPoints = player1Card.currentAttackPoints;
                    player1Card.currentAttackPoints -= player2Card.DefencePoints;
                    player2Card.DefencePoints -= p1AttackPoints;
                    
                    int p2AttackPoints = player2Card.currentAttackPoints;
                    player2Card.currentAttackPoints -= player1Card.DefencePoints;
                    player1Card.DefencePoints -= p2AttackPoints;
                }

                while(player1Card.currentAttackPoints > 0 & player1Card.DefencePoints > 0)
                {
                    int currentAttackPoints = player1Card.currentAttackPoints;
                    int index = 1;

                    try
                    {
                        player1Card.currentAttackPoints -= _player2.CardsInArena[index].DefencePoints;
                        _player2.CardsInArena[index].DefencePoints -= currentAttackPoints;
                    }
                    catch
                    {
                        break;
                    }

                    index++;
                }
                
                while(player2Card.currentAttackPoints > 0 & player2Card.DefencePoints > 0)
                {
                    int currentAttackPoints = player2Card.currentAttackPoints;
                    int index = 1;

                    try
                    {
                        player2Card.currentAttackPoints -= _player1.CardsInArena[index].DefencePoints;
                        _player1.CardsInArena[index].DefencePoints -= currentAttackPoints;
                    }
                    catch
                    {
                        break;
                    }

                    index++;
                }

                foreach (Player player in players)
                {
                    if (player.HealthPoints <= 0)
                    {
                        throw new Exception();
                    }

                    player.CardsInArena.RemoveAll(card => card.DefencePoints <= 0);
                }
            }

            if(_player1.CardsInArena.Count > 0 ^ _player2.CardsInArena.Count > 0)
            {
                if (_player1.CardsInArena.Count > 0)
                {
                    foreach (Card card in _player1.CardsInArena)
                    {
                        _player2.HealthPoints -= card.currentAttackPoints;
                    }
                    _player1.CardsInArena.Clear();
                }
                else
                {
                    foreach(Card card in _player2.CardsInArena)
                    {
                        _player1.HealthPoints -= card.currentAttackPoints;
                    }
                    _player2.CardsInArena.Clear();
                }
            }

            if (_player1.HealthPoints <= 0 | _player2.HealthPoints <= 0)
            {
                throw new Exception();
            }
            
        }
    }
}