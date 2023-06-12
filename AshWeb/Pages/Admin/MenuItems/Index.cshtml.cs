using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }

    }
}
