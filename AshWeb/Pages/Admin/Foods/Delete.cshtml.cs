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
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public Food Foods { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Foods = _unitOfWork.Food.GetFirstOrDefault(u => u.id == id);
        }

        public async Task<IActionResult> OnPost(Food Foods)
        {
            //if(Category.Name==Category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError(string.Empty, "The Display Oder cannot exactly Match the Name.");
            //}
            var catform = _unitOfWork.Food.GetFirstOrDefault(u=>u.id==Foods.id);
            if (catform != null) 
            {
                _unitOfWork.Food.Remove(catform);
                _unitOfWork.Save();
                TempData["Success"] = "Category Delete successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
