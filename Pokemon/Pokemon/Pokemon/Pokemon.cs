using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
        
    }

    public class PokemonResponse
    {
        public Pokemon[] Results { get; set; }
    }
    public class Ability
    {
        public string Name { get; set; }
    }

    public class PokemonDetails
    {
        public string Name { get; set; }
        public string Weight { get; set; }

        public AbilitySlot[] Abilities { get; set; }
        public Sprite Sprites { get; set; }
    }

    public class Sprite
    {
        public Uri Front_default { get; set; }

        public Uri Back_default { get; set; }
    }

    public class AbilitySlot
    {
        public Ability Ability { get; set; }
    }


}
