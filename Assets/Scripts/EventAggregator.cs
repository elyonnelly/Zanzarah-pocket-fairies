﻿using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventAggregator
    {
        // часть событий происходит в UI части, часть в GameLogic

        public delegate void ChangeActiveFairy(int position, string name);

        public delegate void ChangeActiveSpell(int fairyPosition, int spellPosition, string name);

        public delegate void PlayerWin();

        public static event ChangeActiveFairy DisableFairy;
        public static event ChangeActiveFairy ActivateFairy;

        public static event ChangeActiveSpell RemoveSpell;
        public static event ChangeActiveSpell AddSpell;

        public static event PlayerWin PlayerWon;

        public delegate void Attack(int forwardFairy, int victimFairy, string spell, string victim);

        public static event Attack FairyAttack;
        public static event Attack EnemyAttack;

        public delegate void Victory(string winner);

        public static event Victory VictoryInBattle;

        public static void OnDisableFairy(int position, string name)
        {
            DisableFairy?.Invoke(position, name);
        }

        public static void OnActivateFairy(int position, string name)
        {
            ActivateFairy?.Invoke(position, name);
        }

        public static void OnRemoveSpell(int fairyPosition, int spellPosition, string name)
        {
            RemoveSpell?.Invoke(fairyPosition, spellPosition, name);
        }

        public static void OnAddSpell(int fairyPosition, int spellPosition, string name)
        {
            AddSpell?.Invoke(fairyPosition, spellPosition, name);
        }

        public static void OnFairyAttack(int forwardFairy, int victimFairy, string spell, string victim)
        {
            FairyAttack?.Invoke(forwardFairy, victimFairy, spell, victim);
        }

        public static void OnPlayerWon()
        {
            PlayerWon?.Invoke();
        }


        public static void OnEnemyAttack(int forwardfairy, int victimfairy, string spell, string victim)
        {
            EnemyAttack?.Invoke(forwardfairy, victimfairy, spell, victim);
        }

        public static void OnVictoryInBattle(string winner)
        {
            VictoryInBattle?.Invoke(winner);
        }
    }
}