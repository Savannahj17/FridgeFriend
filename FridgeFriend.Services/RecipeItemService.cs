using FridgeFriend.Data;
using FridgeFriend.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Services
{
    public class RecipeItemService
    {
        public bool CreateRecipeItem(RecipeItemCreate model)
        {
            RecipeItem item =
                new RecipeItem
                {
                    ItemID = model.ItemID,
                    ItemName = model.ItemName,
                    Calories = model.Calories,
                    PurchaseDate = model.PurchaseDate,
                    ExpirationDate = model.ExpirationDate,
                    FoodType = model.FoodType,
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
                            ItemName = e.ItemName,
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
                        ItemName = entity.ItemName,
                        PurchaseDate = entity.PurchaseDate,
                        ExpirationDate = entity.ExpirationDate
                    };
            }
        }
        public IEnumerable<RecipeItemListItem> GetRecipeItemsByFridgeId(int fridgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RecipeItems
                        .Where(e => e.FridgeId == fridgeId)
                        .Select(
                        e =>
                        new RecipeItemListItem
                        {
                            ItemID = e.ItemID,
                            ItemName = e.ItemName,
                            PurchaseDate = e.PurchaseDate,
                            ExpirationDate = e.ExpirationDate
                        });
                        return query.ToArray();

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
                entity.ItemName = item.ItemName;
                entity.FoodType = item.FoodType;
                entity.Calories = item.Calories;
                entity.PurchaseDate = item.PurchaseDate;
                entity.ExpirationDate = item.ExpirationDate;
                entity.FoodType = item.FoodType;


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

