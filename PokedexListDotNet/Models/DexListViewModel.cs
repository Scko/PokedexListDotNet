using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexListDotNet.Models
{
    public class DexListViewModel
    {
        public List<DexEntry> DexEntries { get; set; }
    }

    public class DexEntry {
        public bool Caught { get; set; }
        public string Name { get; set; }
    }
}
