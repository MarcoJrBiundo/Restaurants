using System;
using FluentValidation;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;


namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantCommandValidator :AbstractValidator<CreateRestaurantCommand>
{ 
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
             .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("A valid email is required.");
    }
}
