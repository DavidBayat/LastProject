#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LastProject.API;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using RestSharp;
using System.Text.Json;

namespace LastProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        // private IRecipeService _service;
        // private RecipesResponse _recipe;
        // public RecipesController(IRecipeService service, RecipesResponse recipe)
        // {
        //     this._service = service;
        //     this._recipe = recipe;
        // }


        // [HttpGet]
        // public Task<RecipesResponse> GetRecipe()
        // {
        //     var response = this._service.GetRecipe();
        //     return response;
        // }


        // GET: api/Recepes/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<ApiRecepe>> GetRecepe(int id)
        // {
        //     //var user = await _recipe.ListOfRecipes

        //     var part1 = _recipe.ListOfRecipes;

        //     var part2 = (from p in part1
        //                 where p.idMeal == id.ToString()
        //                 select p).First();


        //     if (part2 == null)
        //     {
        //         return NotFound();
        //     }

        //     return part2;
        // }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetRecepeById (string id)
        {
            var client = new RestClient($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}");

            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);

            var mealList = JsonSerializer.Deserialize<ListSearchIdDTO>(response.Content);

            if(string.IsNullOrEmpty(id))
                {
                    return NotFound();
                }
            
            return Ok(mealList);

            // var result = mealList.ListOfRecipes;

            // var final = (from r in result
            //         where r.idMeal == id
            //         select new SearchIdDTO{
            //             strMeal = r.strMeal,
            //             idMeal = r.idMeal,
            //             strMealThumb = r.strMealThumb
            //         }).ToList();
            // return Ok(new ListSearchIdDTO {
            //     ListOfRecipes = final});
        }

        // , string searchByIngredient2, string searchByIngredient3

        [HttpGet("ingredients")]
        public async Task<ActionResult> GetRecipeByIngredient ( string searchByIngredient) //use param later
        {
            var client = new RestClient("https://www.themealdb.com/api/json/v1/1/search.php?s=");

            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);
            
            var mealList = JsonSerializer.Deserialize<RecipesResponse>(response.Content);
            
            // fix it with always full list in case invalid string 
            // if(string.IsNullOrEmpty(searchByIngredient) && string.IsNullOrEmpty(searchByIngredient2) && string.IsNullOrEmpty(searchByIngredient3) || string.IsNullOrEmpty(searchByIngredient))
               
               if(string.IsNullOrEmpty(searchByIngredient))
                {
                    return Ok(mealList);
                }
            
        var result = mealList.ListOfRecipes;

        // var searchStringLower = searchByIngredient.ToLower();
        
        var final = (from r in result
                    where r.Ingredients.Contains(searchByIngredient)
                    // where r.Ingredients.Contains(searchByIngredient2)
                    // where r.Ingredients.Contains(searchByIngredient3)
                    select new SearchResultDTO {
                        strMeal = r.strMeal,
                        idMeal = r.idMeal,
                        strMealThumb = r.strMealThumb
                    }).ToList();

        

            return Ok(new ListSearchDTO {
                ListOfRecipes = final
            });

            //return Ok(final);
        }


    }

    public class RecipesResponse
    {
        [JsonPropertyName("meals")]
        public List<ApiRecepe>? ListOfRecipes { get; set; }
    }


    public class ApiRecepe 
    {   
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strMealThumb {get; set;}
        
        public List<string> Ingredients { 
            get
            {
                return new List<string>()
                {
                    strIngredient1,
                    strIngredient2, 
                    strIngredient3,
                    strIngredient4,
                    strIngredient5,
                    strIngredient6,
                    strIngredient7,
                    strIngredient8,
                    strIngredient9,
                    strIngredient10,
                    strIngredient11,
                    strIngredient12,
                    strIngredient13,
                    strIngredient14,
                    strIngredient15,
                    strIngredient16,
                    strIngredient17,
                    strIngredient18,
                    strIngredient19,
                    strIngredient20
                    };
             } 
        }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strIngredient11 { get; set; }
        public string strIngredient12 { get; set; }
        public string strIngredient13 { get; set; }
        public string strIngredient14 { get; set; }
        public string strIngredient15 { get; set; }
        public string strIngredient16 { get; set; }
        public string strIngredient17 { get; set; }
        public string strIngredient18 { get; set; }
        public string strIngredient19 { get; set; }
        public string strIngredient20 { get; set; }
    
}

}