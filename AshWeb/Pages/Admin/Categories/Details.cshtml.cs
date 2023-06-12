using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DetailsModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;


        public Category Category { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.id==id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Oder cannot exactly Match the Name.");
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
