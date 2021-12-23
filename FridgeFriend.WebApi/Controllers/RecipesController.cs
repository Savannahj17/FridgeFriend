using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FridgeFriend.WebApi.Controllers
{
    public class RecipesController : ApiController
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // post (create)
        //api/Recipes
        [HttpPost]
        public async Task<IHttpActionResult> CreateRecipe([FromBody] Recipe model)
        {
            if (model is null)
            {
                return BadRequest("please enter required information recipe cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //store model in database
                _context.Recipes.Add(model);
                await _context.SaveChangesAsync();

                return Ok("Recipe Created");
            }
            //model is not valid reject
            return BadRequest(ModelState);
        }
        public async Task<IHttpActionResult> GetRecipe()
        {
            List<Recipe> recipes = await _context.Recipes.ToListAsync();
            return Ok(recipes);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRecipeByID([FromUri] int recipeId)
        {
            Recipe recipe = await _context.Recipes.FindAsync(recipeId);

            if(recipe != null)
            {
                return Ok(recipe);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetRecipesByItemID([FromUri] int itemId)
        {
            Recipe recipe = await _context.Recipes.FindAsync(itemId);
            if(recipe != null)
            {
                return Ok(recipe);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateRecipe([FromUri]int recipeId, [FromBody] Recipe updatedRecipe)
        {
            //check the IDs if match
            if(recipeId != updatedRecipe?.RecipeID)
            {
                return BadRequest("ids do not match.");
            }
            //check ModelState
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //find recipe in Database
            Recipe recipe = await _context.Recipes.FindAsync(recipeId);
            //If the recipe Not found
            if (recipe is null)
                return NotFound();

            //update properties
            recipe.RecipeName = updatedRecipe.RecipeName;
            recipe.ServingSize = updatedRecipe.ServingSize;
            //recipe.ItemName = updatedRecipe.ItemName;
            //recipe.NeededItems = updatedRecipe.NeededItems;
            recipe.Type = updatedRecipe.Type;
            //save changes
            await _context.SaveChangesAsync();

            return Ok("The recipe was updated!");

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRecipe([FromUri] int recipeId)
        {
            Recipe recipe = await _context.Recipes.FindAsync(recipeId);

            if (recipe is null)
                return NotFound();
            _context.Recipes.Remove(recipe);
             
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted.");
            }
            return InternalServerError();
        }
    }
}
