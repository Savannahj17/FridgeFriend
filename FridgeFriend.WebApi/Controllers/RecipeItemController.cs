using FridgeFriend.Models.RecipeModels;
using FridgeFriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeFriend.WebApi.Controllers
{
    public class RecipeItemController : ApiController
    {
        private RecipeItemService CreateRecipeItemService()
        {
            var recipeItemService = new RecipeItemService();
            return recipeItemService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            RecipeItemService recipeItemService = CreateRecipeItemService();
            var items = recipeItemService.GetRecipeItems();
            return Ok(items);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            RecipeItemService recipeItemService = CreateRecipeItemService();
            var item = recipeItemService.GetRecipeItemById(id);
            return Ok(item);
        }
        [HttpPost]
        public IHttpActionResult Post(RecipeItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeItemService recipeItemService = CreateRecipeItemService();
            if (!recipeItemService.CreateRecipeItem(item))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(RecipeItemEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeItemService service = CreateRecipeItemService();
            if (!service.UpdateRecipeItem(item))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RecipeItemService service = CreateRecipeItemService();
            bool item = service.DeleteRecipeItem(id);
            if (!item)
            {
                return InternalServerError();
            }
            else
            {
                return Ok();
            }
            // can do if(!service.DeleteRecipeItem(id))
            //return InternalServerError();
            //return Ok();
        }
    }
}

