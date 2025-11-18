using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with ID {Id}", request.Id);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            logger.LogWarning("Restaurant with ID {Id} not found", request.Id);
          return false;
        }
        mapper.Map(request, restaurant);
        await restaurantsRepository.UpdateAsync(restaurant);
        logger.LogInformation("Successfully updated restaurant with ID {Id}", restaurant.Id);
        return true;

    }
}
