
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Net.Http;
using LastProject.API;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using LastProject.API.Controllers;

public class RecipeClient : IRecipeService
{
    public async Task<RecipesResponse> GetRecipe() 
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var stringAsync = client.GetStreamAsync("https://www.themealdb.com/api/json/v1/1/search.php?s=");
        var recipe = await JsonSerializer.DeserializeAsync<RecipesResponse>(await stringAsync);
        // Console.WriteLine(recipe.ListOfRecipes[0].Ingredient1);
        return recipe;

    }
}

// public class GetRecipeResponse
// {
//     public GetRecipeResponse()
//     {
//         Ingredients = new List<RecipeIngredient>();
//     }
//     [JsonPropertyName("idMeal")]
//     public string? Id { get; set; }

//     [JsonPropertyName("strMeal")]
//     public string? RecipeName { get; set; }

//     // [JsonPropertyName("strIngredient1")]
//     // public string Ingredient1 { get; set; }
//     // [JsonPropertyName("strIngredient2")]
//     // public string Ingredient2 { get; set; }

//     // public List<string> Ingredients {get;set;} //{ set; get {return new List<string>(){Ingredient1, Ingredient2};}}

//     public List<RecipeIngredient> Ingredients {get; set; }
   
// }

// public class RecipeIngredient 
// {
//     public string Id {get; set; }
//     // public Dictionary<int, string[]> DischesWithIngr { get; set; }

//     // for (int i = 0; i < 20; i++)
//     // {
//     //     DischesWithIngr.Add()
//     // }

//     // [RegularExpression("\"strIngredient\"")]
//     // public string Ingredient { get; set; }
//     // [JsonPropertyName("strIngredient1")]
//     public string Ingredient1 { get; set; }
//     [JsonPropertyName("strIngredient2")]
//     public string Ingredient2 { get; set; }
// }

public class RecipesResponse
{
    [JsonPropertyName("meals")]
    public List<ApiRecepe>? ListOfRecipes { get; set; }
}

public interface IRecipeService 
{
    Task<RecipesResponse> GetRecipe();
}