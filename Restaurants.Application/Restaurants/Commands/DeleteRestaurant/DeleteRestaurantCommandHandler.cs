using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id {request.Id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
        {
            logger.LogWarning($"Restaurant with id {request.Id} not found");
            return false;
        }
        await restaurantsRepository.DeleteAsync(restaurant);
        return true;
    }
}
