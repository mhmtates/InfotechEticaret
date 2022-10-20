using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts.EntityFramework;
using DataAccess.Concrete.Repositories;
using Entities.DTO;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MyService(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddDbContext<EticaretContext>();
            ServiceCollection.AddScoped<IUnitOfWorks, UnitOfWorks>();
            ServiceCollection.AddScoped<IProductsService, ProductsManager>();
            ServiceCollection.AddScoped<ICategoriesService, CategoriesManager>();
            ServiceCollection.AddScoped<ICustomersService, CustomerManager>();
            ServiceCollection.AddScoped<IOrdersService, OrderManager>();
            ServiceCollection.AddScoped<IUsersAdminService, UserAdminManager>();
            ServiceCollection.AddScoped<IPImagesService, PImagesManager>();
            ServiceCollection.AddScoped<IVariantService, VariantManager>();
            ServiceCollection.AddScoped<ITempBasketsService, TempBasketManager>();
            ServiceCollection.AddScoped<IOrderDetailsService, OrderDetailsManager>();
            ServiceCollection.AddScoped<IOrderInforService, OrderInforManager>();






            // Validation Dependency Tanımlamaları
            ServiceCollection.AddSingleton<IValidator<CategoriesDto>, CategoriesValidation>();
            ServiceCollection.AddSingleton<IValidator<CustomersUpdateDto>, CustomerValidation>();
            ServiceCollection.AddSingleton<IValidator<OrderInfoDto>, OrderInfovalidation>();
            ServiceCollection.AddSingleton<IValidator<OrderNotesDto>, OrderNotesValidation>();
            ServiceCollection.AddSingleton<IValidator<OrderDetailsDto>, OrdersDetailValidation>();
            ServiceCollection.AddSingleton<IValidator<OrderUpdateDto>, OrdersValidation>();
            ServiceCollection.AddSingleton<IValidator<PImagesDto>, PImagesValidation>();
            ServiceCollection.AddSingleton<IValidator<ProductsUpdateDto>, ProductValidation>();
            ServiceCollection.AddSingleton<IValidator<UsersAdminDto>, UsersAdminValidation>();
            ServiceCollection.AddSingleton<IValidator<VariantsDto>, VariantsValidation>();

            return ServiceCollection;
        }

    }
}
