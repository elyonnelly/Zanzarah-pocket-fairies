﻿using System;
using Newtonsoft.Json;


namespace Assets.Scripts.GameLogic.DataModels
{
    public class Spell : ICloneable
    {
        [JsonProperty("Name")]
        public string Name { private set; get; }

        [JsonProperty("Mana")]
        public int Mana { set; get; }

        [JsonProperty("MajorElement")]
        public Element MajorElement { private set; get; }


        [JsonProperty("MinorElement")]
        public Element MinorElement { private set; get; }

        [JsonProperty("Level")]
        public int Level { private set; get; }

        
        [JsonProperty("Effect")]
        public double Effect { private set; get; }

        [JsonProperty("Characteristic")]
        public double Characteristic { private set; get; }

        [JsonProperty("Info")]
        public string Info { private set; get; }

        
        public Spell(Element majorElement, int level, string name, int mana, Element minorElement)
        {
            Name = name;
            MajorElement = majorElement;
            MinorElement = minorElement;
            Mana = mana;
            Level = level;
        }

        public Spell(string name)
        {
            Name = name;
        }

        public Spell()
        {

        }


        public object Clone()
        {
            return new Spell(MajorElement, Level, Name, Mana, MinorElement);
        }




    }
}