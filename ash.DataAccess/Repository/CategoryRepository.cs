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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDataContext _db;


        public CategoryRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            var objFromDb=_db.Category.FirstOrDefault(u=>u.id == category.id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
