using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        
  
        // GET: api/Restaurants
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
             var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
             return Ok(restaurants);
        }

   
        [HttpGet("{id:int}", Name = "GetRestaurantById")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
             var restaurant = await mediator.Send(new GetRestuarantByIdQuery(id));
             if (restaurant == null)
             {
                return NotFound();
             }
             return Ok(restaurant);
        }

        [HttpPost]
        public  async Task<IActionResult> CreateRestaurant( [FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await mediator.Send(createRestaurantCommand);
            
            return CreatedAtRoute("GetRestaurantById", new { id = id }, null);
        }


        [HttpDelete("{id:int}", Name = "DeleteRestaurantById")]
         public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        { 
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id)); // Placeholder for actual deletion logic
           
            if (isDeleted is false)
                return NoContent();  
    
             return Ok(isDeleted);
        }

        [HttpPatch("{id:int}", Name = "UpdateRestaurantById")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            updateRestaurantCommand.Id = id;
            var isUpdated = await mediator.Send(updateRestaurantCommand);
            if (isUpdated)
                return NoContent();

            return BadRequest("Failed to update restaurant with ID {Id}.".Replace("{Id}", id.ToString()));
        }

    }
}
