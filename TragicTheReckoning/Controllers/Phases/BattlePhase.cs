﻿using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BattlePhase : IPhase
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

        private void BattlePhaseLoop(Player[] players)
        {
            ResetAttackValues(players);
            
            _battleView.RenderCardsInField(players);

            while (_player1.CardsInArena.Count > 0 && _player2.CardsInArena.Count > 0)
            {
                Card player1Card = _player1.CardsInArena[0];
                Card player2Card = _player2.CardsInArena[0];

                if (player1Card.currentAttackPoints <= 0 && player2Card.currentAttackPoints <= 0)
                {
                    _battleView.NoDamageDealt(_player1, player1Card, _player2, player2Card);
                    break;
                }

                if (player1Card.DefencePoints > 0 && player2Card.DefencePoints > 0)
                {
                    CardCombat(player1Card, player2Card);
                }

                ExtraDamage(player1Card, _player2);
                ExtraDamage(player2Card, _player1);
            }
            
            foreach (Player player in players)
            {
                RemoveDeadCards(players);
            }

            OneSidedResolver(_player1, _player2);

            CheckDeadPlayer(_player1, _player2);
        }

        private void ResetAttackValues(Player[] players)
        {
            foreach (Player player in players)
            {
                foreach (Card card in player.CardsInArena)
                {
                    card.currentAttackPoints = card.maxAttackPoints;
                }
            }
        }

        private void CardCombat(Card card1, Card card2)
        {
            int attackPoints = card1.currentAttackPoints;
            card1.currentAttackPoints -= card2.DefencePoints;
            card2.DefencePoints -= attackPoints;

            attackPoints = card2.currentAttackPoints;
            card2.currentAttackPoints -= card1.DefencePoints;
            card1.DefencePoints -= attackPoints;
        }

        private void ExtraDamage(Card card, Player otherPlayer)
        {
            while (card.currentAttackPoints > 0 && card.DefencePoints > 0)
            {
                int currentAttackPoints = card.currentAttackPoints;
                int index = 1;

                try
                {
                    card.currentAttackPoints -= otherPlayer.CardsInArena[index].DefencePoints;
                    otherPlayer.CardsInArena[index].DefencePoints -= currentAttackPoints;
                }
                catch
                {
                    break;
                }
                
                index++;
            }
        }

        private void RemoveDeadCards(Player[] players)
        {
            foreach (Player player in players)
            {
                player.CardsInArena.RemoveAll(card => card.DefencePoints <= 0);
            }
        }

        private void OneSidedResolver(Player player1, Player player2)
        {
            if (!(player1.CardsInArena.Count > 0 ^ player2.CardsInArena.Count > 0)) return;
            if (player1.CardsInArena.Count > 0)
            {
                foreach (Card card in player1.CardsInArena)
                {
                    _player2.HealthPoints -= card.currentAttackPoints;
                }
                _player1.CardsInArena.Clear();
            }
            else
            {
                foreach (Card card in _player2.CardsInArena)
                {
                    _player1.HealthPoints -= card.currentAttackPoints;
                }
                _player2.CardsInArena.Clear();
            }
        }

        private void CheckDeadPlayer(Player player1, Player player2)
        {
            if (_player1.HealthPoints <= 0)
            {
                _battleView.RenderPlayerDeath(_player1);
                throw new Exception();
            }
            else if (_player2.HealthPoints <= 0)
            {
                _battleView.RenderPlayerDeath(_player2);
                throw new Exception();
            }
        }
    }
}