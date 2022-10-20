using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.ViewComponents
{
    public class KategoriViewComponent : ViewComponent
    {
        private readonly ICategoriesService db;
        public KategoriViewComponent(ICategoriesService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAll(0).Data);
        }
    }
}
