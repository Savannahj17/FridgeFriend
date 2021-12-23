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
        /*[HttpGet]
        public IHttpActionResult Get()
        {
            RecipeService recipeService = CreateRecipeService();
            var item = recipeService.GetRecipe();
            return Ok(item);
        }*/

        [HttpPost]
        public IHttpActionResult Post(RecipeCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeService recipeService = CreateRecipeService();
            if (!recipeService.RecipeCreate(item))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(RecipeEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeService service = CreateRecipeService();
            if (!service.UpdateRecipe(item))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RecipeService service = CreateRecipeService();
            bool item = service.DeleteRecipe(id);
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
