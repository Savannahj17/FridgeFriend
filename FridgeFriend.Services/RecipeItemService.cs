using FridgeFriend.Data;
using FridgeFriend.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Services
{
    class RecipeItemService
    {
        public bool CreateRecipeItem(RecipeItemCreate model)
        {
            RecipeItem item =
                new RecipeItem
                {
                    ItemID = model.ItemID,
                    Name = model.Name,
                    Calories = model.Calories,
                    PurchaseDate = model.PurchaseDate,
                    ExpirationDate = model.ExpirationDate,
                    Type = model.Type,
                    FridgeId = model.FridgeId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeItems.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeItemListItem> GetRecipeItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RecipeItems
                    .ToList();
                List<RecipeItemListItem> recipeItem = new List<RecipeItemListItem>();
                foreach (RecipeItem e in query)
                {
                    RecipeItemListItem item = new RecipeItemListItem
                        {
                        ItemID = e.ItemID,
                            Name = e.Name,
                            Calories = e.Calories,
                            ExpirationDate = e.ExpirationDate
                        };
                    recipeItem.Add(item);
                }

                return recipeItem;
            }
        }
        public RecipeItemDetail GetRecipeItemById(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeItems
                    .Single(e => e.ItemID == recipeId);
                return
                    new RecipeItemDetail
                    {
                        ItemID = entity.ItemID,
                        Name = entity.Name,
                        PurchaseDate = entity.PurchaseDate,
                        ExpirationDate = entity.ExpirationDate
                    };
            }
        }
        public bool UpdateRecipeItem(RecipeItemEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RecipeItems
                        .Single(e => e.ItemID == item.ItemID);
                entity.Name = item.Name;
                entity.Type = item.Type;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipeItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeItems
                    .Single(e => e.ItemID == itemId);
                ctx.RecipeItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

