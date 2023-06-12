using ash.DataAccess.Data;
using ash.DataAccess.Repository;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Foods
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public Food Foods { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Foods = _unitOfWork.Food.GetFirstOrDefault(u => u.id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Food.Update(Foods);
                _unitOfWork.Save();
                TempData["Success"] = "Category Updated successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
