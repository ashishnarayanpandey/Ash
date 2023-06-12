using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Foods
{
    [BindProperties]
    public class CreateModel : PageModel
    {


        private readonly IUnitOfWork _unitOfWork;


        public Food Foods { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Food.Add(Foods);
                _unitOfWork.Save();
                TempData["Success"] = "Category Add successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
