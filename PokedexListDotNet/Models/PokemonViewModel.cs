using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexListDotNet.Models
{
    public class PokemonViewModel
    {
        public string Name { get; set; }
        public Sprite Sprites { get; set; }
        public List<AbilityVM> Abilities { get; set; }
        public List<PTypesVM> Types { get; set; }
        public List<MoveVM> Moves { get; set; }
        public List<MoveVM> Moves2 { get; set; }
        public List<StatVM> Stats { get; set; }

        public string primaryColor { get; set; }
        public string secondaryColor { get; set; }
        public string method { get; set; }
        public string version { get; set; }
    }

    public class PTypesVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class AbilityVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class StatVM
    {
        public int Base_Stat { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class MoveVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Level_Learned_At { get; set; }
        public string MoveLearnMethod { get; set; }
        public string VersionGroup { get; set; }

    }
}
