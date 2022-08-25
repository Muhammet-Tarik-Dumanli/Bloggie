namespace Bloggie.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController  //Kendi oluşturduğumuz AdminBaseController'dan miras aldık, admin ve authorize özelikklerini admin panallerinde tekrar tekrar yazmak zorunda kalmayacağız.
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var vm = new DashboardViewModel()
            {
                CategoryCount = _db.Categories.Count(),
                PostCount = _db.Posts.Count(),
                UserCount = _db.Users.Count()
            };

            return View(vm);
        }
    }
}
