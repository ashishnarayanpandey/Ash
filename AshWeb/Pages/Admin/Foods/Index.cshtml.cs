using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Foods
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<Food> Foods { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void OnGet()
        {
            Foods = _unitOfWork.Food.GetAll();
        }
    }
}
