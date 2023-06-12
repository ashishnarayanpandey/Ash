using ash.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AshWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,Food");
            return Json(new { data = menuItemList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFormDb = _unitOfWork.MenuItem.GetFirstOrDefault(u=>u.id == id);
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFormDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.MenuItem.Remove(objFormDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Success"});
        }
    }
}
