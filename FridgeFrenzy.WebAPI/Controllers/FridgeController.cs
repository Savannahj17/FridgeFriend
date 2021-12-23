using FridgeFrenzy.Model;
using FridgeFrenzy.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeFrenzy.WebAPI.Controllers
{
    [Authorize]

    public class FridgeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            FridgeService fridgeService = CreateFridgeService();
            var fridges = fridgeService.GetFridges();
            return Ok(fridges);
        }
        public IHttpActionResult GetById(int id)
        {
            FridgeService fridgeService = CreateFridgeService();
            var fridge = fridgeService.GetFridgeById(id);
            return Ok(fridge);
        }

        [HttpPost]
        public IHttpActionResult Post(FridgeCreate fridge)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFridgeService();

            if (!service.CreateFridge(fridge))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        [Route("api/category/getcategorybyname/{name}")]
        public IHttpActionResult Edit(FridgeEdit fridge)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFridgeService();

            if (!service.UpdateFridge(fridge))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        //public IHttpActionResult Edit(Fridge fridge)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateFridgeService();

            if (!service.DeleteFridge(id))
                return InternalServerError();

            return Ok();
        }


        private FridgeService CreateFridgeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var fridgeService = new FridgeService(userId);
            return fridgeService;
        }
    }
}
