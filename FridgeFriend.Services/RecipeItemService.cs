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
        //public IEnumerable<RecipeItemListItem> GetRecipeItemsByRecipeId(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var items = new List<RecipeList>();
        //        foreach(var e in ctx.RecipeItems)
        //        {
        //            if (e.)
        //        }
        //    }
        //}
        public bool UpdateRecipeItem(RecipeItemEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RecipeItems
                        .Single(e => e.ItemID == item.ItemID);
                entity.ItemName = item.ItemName;
                entity.FoodType = item.Type;

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

