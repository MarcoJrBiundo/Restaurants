using System;
using FluentValidation;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;


namespace Restaurants.Application.Restaurants.Validators;

public class UpdateRestaurantCommandValidator :AbstractValidator<UpdateRestaurantCommand>
{ 
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 100);

    }
}
