using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<Category>  Category { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            Category = _unitOfWork.Category.GetAll();
        }
    }
}
