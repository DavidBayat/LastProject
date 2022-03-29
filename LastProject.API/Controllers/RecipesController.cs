#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private IRecipeService _service;
        private GetRecipeResponse _recipe;
        public RecipesController(IRecipeService service)
        {
            this._service = service;
        }
        [HttpGet]
        public Task<RecipesResponse> GetRecipe()
        {
            var response = this._service.GetRecipe();
            return response;
        }


        // GET: api/Cds
        // [HttpGet]
        // public async Task<ActionResult<GetRecipeResponse>> GetRecipeByIngredient (string searchByIngredient)
        // {
        //      var recipes = GetRecipe();   

        //     var recipes = 
        //         from c in
        //         select c;

        //     if (searchByIngredient == "")
        //     {
        //         cds = cds.OrderBy(c => c.Id);
        //     }
        //     else if(!String.IsNullOrEmpty(searchByIngredient))
        //     {
        //         cds = cds.Where((s => s.Genre.Name.Contains(searchByIngredient)));
                
        //         // add IF in case there are no vds for that genre! (List all CDs)
        //     }
            
        //     return await cds.ToListAsync();
        // }
    }

}