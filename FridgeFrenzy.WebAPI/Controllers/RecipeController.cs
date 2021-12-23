using FridgeFrenzy.Model;
using FridgeFrenzy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeFrenzy.WebAPI.Controllers
{
    public class RecipeController : ApiController
    {
        private RecipeService CreateRecipeItemService()
        {
            var recipeItemService = new RecipeService();
            return recipeItemService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            RecipeItemService recipeItemService = CreateRecipeService();
            var item = recipeItemService.GetRecipeItemById(id);
            return Ok(item);
        }

        [HttpPost]
        public IHttpActionResult Post(RecipeCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeItemService recipeItemService = CreateRecipeService();
            if (!recipeItemService.CreateRecipeItem(item))
                return InternalServerError();
            return Ok();
        }

    }
}
