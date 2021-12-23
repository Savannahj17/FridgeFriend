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
        private RecipeService CreateRecipeService()
        {
            var recipeItemService = new RecipeService();
            return recipeItemService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            RecipeService recipeService = CreateRecipeService();
            var item = recipeService.GetRecipeById(id);
            return Ok(item);
        }

        [HttpPost]
        public IHttpActionResult Post(RecipeCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var recipeItemService = CreateRecipeService();
            if (!recipeItemService.RecipeCreate(item))
                return InternalServerError();
            return Ok();
        }

    }
}
