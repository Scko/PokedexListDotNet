using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokedexListDotNet.Models;

namespace PokedexListDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class PokeApiResponse 
        {
            public int Count { get; set; }
            public string Next { get; set; }
            public string Previous { get; set; }
            public List<Entry> Results { get; set; }
        }
        public class Entry 
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
        public async Task<IActionResult> IndexAsync()
        {
            PokeApiResponse pokeApiResponse = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage result = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/?limit=151");
                var responseBody = await result.Content.ReadAsStringAsync();
                pokeApiResponse = JsonConvert.DeserializeObject<PokeApiResponse>(responseBody);
            }

            var dexListVM = new DexListViewModel
            {
                DexEntries = new List<DexEntry>()
            };

            foreach (var entry in pokeApiResponse.Results) 
            {
                dexListVM.DexEntries.Add(new DexEntry { Caught= false, Name = entry.Name});
            }
            return View(dexListVM);
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> PokemonAsync(string name, string method = "level-up", string version = "ultra-sun-ultra-moon")
        {
            name = name.ToLower();
            Pokemon pokeApiResponse = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage result = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
                var responseBody = await result.Content.ReadAsStringAsync();
                pokeApiResponse = JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }

            
            var pokemonVM = new PokemonViewModel 
            { 
                Name = pokeApiResponse.Name,
                Types = pokeApiResponse.Types.Select(t => new PTypesVM { Name = t.Type.Name }).ToList(),
                Abilities = pokeApiResponse.Abilities.Select(a => new AbilityVM { Name = a.Ability.Name }).ToList(),
                Sprites = pokeApiResponse.Sprites,
                Stats = pokeApiResponse.Stats.Select(s => new StatVM { Name = s.Stat.Name, Base_Stat = s.Base_Stat }).ToList(),
                Moves = pokeApiResponse.Moves.SelectMany(move => move.Version_Group_Details.Select(version => new MoveVM
                {
                    Name = move.Move.Name,
                    VersionGroup = version.Version_Group.Name,
                    Level_Learned_At = version.Level_Learned_At,
                    MoveLearnMethod = version.Move_Learn_Method.Name
                })).ToList()
            };
            pokemonVM.primaryColor = typeToColor(pokemonVM.Types[0].Name);
            if (pokemonVM.Types.Count>1) 
            {
                pokemonVM.secondaryColor = typeToColor(pokemonVM.Types[1].Name);
            }
            pokemonVM.method = method;
            pokemonVM.version = version;
            pokemonVM.Moves = pokemonVM.Moves.Where(m => m.MoveLearnMethod == pokemonVM.method && m.VersionGroup == pokemonVM.version).ToList();
            return View(pokemonVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string typeToColor(string type)
        {
            var color = "";
            switch (type)
            {
                case "grass":
                    color = "#2FCF27";
                    break;
                case "fire":
                    color = "#E26532";
                    break;
                case "water":
                    color = "#326DE2";
                    break;
                case "poison":
                    color = "#8317D8";
                    break;
                case "flying":
                    color = "#D3FDFC";
                    break;
                case "electric":
                    color = "#E3EE5A";
                    break;
                case "fighting":
                    color = "#C0840D";
                    break;
                case "psychic":
                    color = "#BF1BE3";
                    break;
                case "ghost":
                    color = "#B28DBA";
                    break;
                case "steel":
                    color = "#8C8C89";
                    break;
                case "dark":
                    color = "#4D4D4D";
                    break;
                case "normal":
                    color = "#F8F8F8";
                    break;
                case "bug":
                    color = "#2FCF27";
                    break;
                case "ground":
                    color = "#8E8665";
                    break;
                case "rock":
                    color = "#AA9855";
                    break;
                case "fairy":
                    color = "#F982CC";
                    break;
                case "ice":
                    color = "#3DE5E1";
                    break;
                case "dragon":
                    color = "#47487B";
                    break;
                default:
                    color = "white";
                    break;
            }
            return color;
        }

    }
}
