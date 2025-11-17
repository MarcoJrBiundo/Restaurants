using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.RestaurantsDtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestuarantByIdQueryHandler(ILogger<GetRestuarantByIdQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestuarantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestuarantByIdQuery request, CancellationToken cancellationToken)
    {
       logger.LogInformation($"Retrieving restaurant with id {request.Id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}
