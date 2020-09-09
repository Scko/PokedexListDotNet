using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexListDotNet.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<AbilityItem> Abilities { get; set; }
        public List<TypeItem> Types { get; set; }
        public List<MoveItem> Moves { get; set; }
        public List<StatItem> Stats { get; set; }
        public Sprite Sprites { get; set; }

    }

    public class Sprite
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }

        public Other other { get; set; }

    }

    public class Other
    {
        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork {get;set;}
    }
    public class OfficialArtwork
    {
        public string front_default { get; set; }
    }

    public class StatItem
    {
        public Stat Stat { get; set; }
        public int Base_Stat { get; set; }
        public int Effort { get; set; }
    }

    public class Stat
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class MoveItem
    {
        public Move Move { get; set; }
        public List<VersionGroupDetails> Version_Group_Details { get; set; }
    }

    public class VersionGroupDetails
    {
        public int Level_Learned_At { get; set; }
        public MoveLearnMethod Move_Learn_Method { get; set; }
        public VersionGroup Version_Group { get; set; }
    }

    public class VersionGroup
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class MoveLearnMethod
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class AbilityItem
    {
        public Ability Ability { get; set; }
        public bool Is_Hidden { get; set; }
        public int Slot { get; set; }
    }

    public class TypeItem
    {
        public PTypes Type { get; set; }
        public int Slot { get; set; }
    }
    public class PTypes
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
