using System;
using MediatR;
using Restaurants.Application.RestaurantsDtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{

}
