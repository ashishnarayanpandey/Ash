using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshWeb.Pages.Admin.Foods
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public Food Foods { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
            Foods = _unitOfWork.Food.GetFirstOrDefault(u=>u.id==id);
        }

    }
}
