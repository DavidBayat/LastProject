
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Net.Http;
using LastProject.API;
using System.Net.Http.Headers;

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
        return recipe;

    }
}

public class GetRecipeResponse
{
    [JsonPropertyName("idMeal")]
    public string? Id { get; set; }

    [JsonPropertyName("strMeal")]
    public string? RecipeName { get; set; }
   
}
public class RecipesResponse
{
    [JsonPropertyName("meals")]
    public List<GetRecipeResponse>? ListOfRecipes { get; set; }
}

public interface IRecipeService 
{
    Task<RecipesResponse> GetRecipe();
}