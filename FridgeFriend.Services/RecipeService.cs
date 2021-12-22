using FridgeFriend.Data;
using FridgeFriend.Models;
using FridgeFriend.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Services
{
    class RecipeService
    {
        public bool RecipeCreate(RecipeCreate model)
        {
            Recipe item =
                new Recipe
                {
                    RecipeID = model.RecipeID,
                    RecipeName = model.RecipeName,
                    ServingSize = model.ServingSize,
                    Type = model.Type, //adding multiple items to a recipe? 
                    ItemName = model.ItemName,
                    NeededItems = model.NeededItems
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }
        
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
                        Type = entity.Type,
                        //Items = entity.Items,
                        NeededItems = entity.NeededItems

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
