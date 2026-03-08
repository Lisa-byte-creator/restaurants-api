using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Restaurants.Application.Restaurants.Validators;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

        services.AddValidatorsFromAssemblyContaining<CreateRestaurantCommandValidator>();
    }
}