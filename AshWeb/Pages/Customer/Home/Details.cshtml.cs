using ash.DataAccess.Migrations;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AshWeb.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }

       

        public void OnGet(int id)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);


            ShoppingCart = new()
            {
                ApplicationUserid = claim.Value,
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.id == id, includeProperties: "Category,Food"),
                MenuItemid = id
            };
        }

        public ActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shopingCartFormDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                   filter: u => u.ApplicationUserid == ShoppingCart.ApplicationUserid && u.MenuItemid == ShoppingCart.MenuItemid);
                if(shopingCartFormDb==null)
                {
                    _unitOfWork.ShoppingCart.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ShoppingCart.IncrementCount(shopingCartFormDb, ShoppingCart.Count);
                }

                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}

