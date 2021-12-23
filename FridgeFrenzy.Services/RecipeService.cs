using FridgeFrenzy.Data;
using FridgeFrenzy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Services
{
   public class RecipeService
    {
        public bool RecipeCreate(RecipeCreate model)
        {
            Recipe item =
                new Recipe
                {
                    RecipeID = model.RecipeID,
                    RecipeName = model.RecipeName,
                    ServingSize = model.ServingSize,
                    RecipeText = model.RecipeText,
                    Type = model.Type, 
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }
        /*public IEnumerable<ListofRecipes> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Select(
                        e => new ListOfRecipes
                        {
                            RecipeID = e.RecipeID,
                            RecipeItemID = e.RecipeItemID,
                            RecipeName = e.RecipeName,
                            Type = e.Type,

                        })
            }
        }*/
        

        public RecipeDetail GetRecipeById(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == recipeId);
                return
                    new RecipeDetail
                    {
                        RecipeID = entity.RecipeID,
                        RecipeName = entity.RecipeName,
                        ServingSize = entity.ServingSize,
                        RecipeText = entity.RecipeText,
                        Type = entity.Type,
                        


                    };
            }
        }
        public bool UpdateRecipe(RecipeEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeID == item.RecipeID);
                entity.RecipeName = item.RecipeName;
                entity.Type = item.Type;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int RecipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == RecipeId);
                ctx.Recipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
