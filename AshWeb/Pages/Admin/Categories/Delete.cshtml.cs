
using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {


        private readonly IUnitOfWork _unitOfWork;


        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.id==id);
        }

        public async Task<IActionResult> OnPost(Category category)
        {
            //if(Category.Name==Category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError(string.Empty, "The Display Oder cannot exactly Match the Name.");
            //}
            var catform = _unitOfWork.Category.GetFirstOrDefault(u=>u.id==category.id);
            if (catform != null) 
            {

                _unitOfWork.Category.Remove(catform);
                _unitOfWork.Save();
                TempData["Success"] = "Category Delete successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
