using AutoMapper;
using Entities.Concrete;
using Entities.DTO;

namespace Business.AutoMapper.Profiles
{
    public class AllProfile : Profile
    {
        public AllProfile()
        {
            CreateMap<ProductsUpdateDto, Products>(); // Dto To Entity Convert
            CreateMap<Products, ProductsUpdateDto>(); // Entity To Dto Convert
            CreateMap<Products, ProductsDto>(); // Entity To Dto Convert
            CreateMap<PImagesDto, PImages>(); // Dto To Entity Convert
            CreateMap<PImages, PImagesDto>(); // Entity To Dto Convert
            CreateMap<VariantsDto, Variants>(); // Dto To Entity Convert
            CreateMap<Variants, VariantsDto>(); // Entity To Dto Convert
            CreateMap<CategoriesDto, Categories>(); // Dto To Entity Convert
            CreateMap<Categories, CategoriesDto>(); // Entity To Dto Convert
            CreateMap<CustomersUpdateDto, Customers>(); // Dto To Entity Convert
            CreateMap<Customers, CustomersUpdateDto>(); // Entity To Dto Convert
            CreateMap<Customers, CustomersDto>(); // Entity To Dto Convert
            CreateMap<OrderUpdateDto, Orders>(); // Dto To Entity Convert
            CreateMap<Orders, OrderUpdateDto>(); // Entity To Dto Convert
            CreateMap<Orders, OrdersDto>(); // Entity To Dto Convert
            CreateMap<OrderDetailsDto, OrderDetails>(); // Dto To Entity Convert
            CreateMap<OrderDetails, OrderDetailsDto>(); // Entity To Dto Convert
            CreateMap<OrderInfoDto, OrderInformations>(); // Dto To Entity Convert
            CreateMap<OrderInformations, OrderInfoDto>(); // Entity To Dto Convert
            CreateMap<OrderNotesDto, OrderNotes>(); // Dto To Entity Convert
            CreateMap<OrderNotes, OrderNotesDto>(); // Entity To Dto Convert
            CreateMap<TempBasketDto, TempBaskets>(); // Dto To Entity Convert
            CreateMap<TempBaskets, TempBasketDto>(); // Entity To Dto Convert
            CreateMap<UsersAdminDto, UsersAdmin>(); // Dto To Entity Convert
            CreateMap<UsersAdmin, UsersAdminDto>(); // Entity To Dto Convert
            CreateMap<Orders, OrderUpdateListDto>(); // Entity To Dto Convert
            CreateMap<OrderUpdateListDto, Orders>(); // Dto To Entity Convert
            CreateMap<AutoBasket, AutoBasketDto>(); // Entity To Dto Convert
            CreateMap<AutoBasketDto, AutoBasket>(); // Dto To Entity Convert
        }
    }
}
