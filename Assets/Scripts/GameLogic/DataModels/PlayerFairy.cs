﻿using System;

namespace Assets.Scripts.GameLogic.DataModels
{
    public class PlayerFairy : Fairy
    {
        public override void Attack(Fairy victim, OffensiveSpell spell)
        {
            //TODO добавить обработку коэфициента в зависимости от стихии феи
            Magic -= spell.Mana;
            victim.HealthPoint -= (int)spell.Damage;
        }

        public override void CastSpell(Spell spell)
        {
            throw new NotImplementedException();
        }

        public override void FairyDeath()
        {
            throw new NotImplementedException();
        }

        public void ChangeSpell()
        {
            throw new System.NotImplementedException();
        }

        public PlayerFairy() :base()
        {

        }
        public PlayerFairy(string name, string description, Element element) : base(name,description, element)
        {
        }
    }
}