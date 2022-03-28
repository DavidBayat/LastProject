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
    }

}