using ash.DataAccess.Data;
using ash.DataAccess.Repository;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;

namespace AshWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpdInsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuItem MenuItems { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodList { get; set; }

        public UpdInsModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            MenuItems = new();
        }

        
        public void OnGet(int? id)
        {
            if(id!=null)
            {
                //Edit
                MenuItems = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.id == id);

            }
            
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.id.ToString()
            });
            FoodList = _unitOfWork.Food.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.id.ToString()
            });
        }

        public async Task<IActionResult> OnPost(MenuItem MenuItems)
        {
            string webrootpath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItems.id==0)
            {
                //create
                string fileName_new = Guid.NewGuid().ToString();
                var upload=Path.Combine(webrootpath, @"Images\MenuItem");
                var exention = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(upload, fileName_new + exention), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                MenuItems.Image = @"\Images\MenuItem\" + fileName_new + exention;
                _unitOfWork.MenuItem.Add(MenuItems);
                _unitOfWork.Save();

            }
            else
            {
                //edit
                var objFormDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.id == MenuItems.id);
                if (files.Count > 0)
                {
                    string fileName_New = Guid.NewGuid().ToString();
                    var upload = Path.Combine(webrootpath, @"Images\MenuItem");
                    var extension= Path.GetExtension(files[0].FileName);

                    //delete the old image

                    var oldImagePath = Path.Combine(webrootpath, objFormDb.Image.TrimStart('\\'));
                    if(System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    //new upload
                    using (var filestream = new FileStream(Path.Combine(upload, fileName_New + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    MenuItems.Image = @"\Images\MenuItem\" + fileName_New + extension;

                }
                else
                {
                    MenuItems.Image = objFormDb.Image;
                }
                _unitOfWork.MenuItem.Update(MenuItems);
                _unitOfWork.Save();

            }

            return RedirectToPage("./Index");
            
        }
    }
}
