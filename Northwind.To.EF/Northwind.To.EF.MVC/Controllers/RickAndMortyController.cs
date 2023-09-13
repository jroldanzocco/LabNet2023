using Newtonsoft.Json;
using Northwind.To.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Northwind.To.EF.MVC.Controllers
{
    public class RickAndMortyController : Controller
    {
        // GET: RickAndMorty
        public async Task<ActionResult> Index()
        {
            List<RickAndMortyViewModel> characters = await GetCharacters();
            return View(characters);
        }
        public async Task<List<RickAndMortyViewModel>> GetCharacters()
        {
            var cliente = new HttpClient();

            List<RickAndMortyViewModel> characters = null;

            HttpResponseMessage response = await cliente.GetAsync("https://rickandmortyapi.com/api/character/1,2,3,4,5,6,7,8,9,10");

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                characters = JsonConvert.DeserializeObject<List<RickAndMortyViewModel>>(json);
            }
            return characters;
        }
    }
}