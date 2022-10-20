using DataAccess.Abstract;
using DataAccess.Concrete.Contexts.EntityFramework;
using DataAccess.Concrete.Repositories.EntityRepo;

namespace DataAccess.Concrete.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly EticaretContext context;
        private CategoriesRepository categories;
        private ProductsRepository products;
        private VariantRepository variant;
        private PImagesRepository pImages;
        private CustomerRepository customer;
        private OrderDetailsRepository orderdetail;
        private OrderInformationsRepository orderinfo;
        private OrderNotesRepository ordernote;
        private OrdersRepository orders;
        private TempBasketsRepository Tempbasket;
        private UsersAdminRepository useradmin;
        private AutoBasketRepository autoBasketRepo;
        public UnitOfWorks(EticaretContext _context)
        {
            context = _context;
        }
        public IProductsRepository ProductsRepository => products ?? new ProductsRepository(context);
        public ICategoriesRepository CategoriesRepository => categories ?? new CategoriesRepository(context);
        public IVariantRepository VariantRepository => variant ?? new VariantRepository(context);
        public IPImagesRepository PImagesRepository => pImages ?? new PImagesRepository(context);
        public ICustomersRepository CustomersRepository => customer ?? new CustomerRepository(context);
        public IOrderDetailsRepository OrderDetailsRepository => orderdetail ?? new OrderDetailsRepository(context);
        public IOrderInformationsRepository OrderInformationsRepository => orderinfo ?? new OrderInformationsRepository(context);
        public IOrderNotesRepository OrderNotesRepository => ordernote ?? new OrderNotesRepository(context);
        public IOrdersRepository OrdersRepository => orders ?? new OrdersRepository(context); // Ternary IF
        public ITempBasketRepository TempBasketRepository => Tempbasket ?? new TempBasketsRepository(context);
        public IUsersAdminRepository UsersAdminRepository => useradmin ?? new UsersAdminRepository(context);

        public IAutoBasketRepository AutoBasketRepository => autoBasketRepo ?? new AutoBasketRepository(context);
        public void Dispose()
        {
            context.Dispose();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
