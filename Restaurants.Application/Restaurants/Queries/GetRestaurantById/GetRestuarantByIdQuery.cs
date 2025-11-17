using System;
using MediatR;
using Restaurants.Application.RestaurantsDtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestuarantByIdQuery : IRequest<RestaurantDto?>
{
    public GetRestuarantByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
