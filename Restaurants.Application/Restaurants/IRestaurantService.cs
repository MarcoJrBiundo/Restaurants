using System;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.RestaurantsDtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantService
{

    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto> GetRestaurantById(int id);


}
