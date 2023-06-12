using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDataContext _db;


        public MenuItemRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }
        
        public void Update(MenuItem obj)
        {
            var objFromDb=_db.MenuItems.FirstOrDefault(u=>u.id == obj.id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.Categoryid = obj.Categoryid;
            objFromDb.Foodid = obj.Foodid;
            if(obj.Image!=null)
            {
                objFromDb.Image = obj.Image;
            }



        }
    }
}
