using System;

namespace DataAccess.Abstract
{
    public interface IUnitOfWorks:IDisposable
    {
        IProductsRepository ProductsRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        IVariantRepository VariantRepository { get; }
        IPImagesRepository PImagesRepository { get; }
        ICustomersRepository CustomersRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderInformationsRepository OrderInformationsRepository { get; }
        IOrderNotesRepository OrderNotesRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        ITempBasketRepository TempBasketRepository { get; }
        IUsersAdminRepository UsersAdminRepository { get; }
        IAutoBasketRepository AutoBasketRepository { get; }
        void SaveChanges();
    }
}
