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
    public class FoodTypeRepository : Repository<Food>, IFoodTypeRepository
    {
        private readonly ApplicationDataContext _db;


        public FoodTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }
        
        public void Update(Food obj)
        {
            var objFromDb=_db.Foods.FirstOrDefault(u=>u.id == obj.id);
            objFromDb.Name = obj.Name;
            
        }
    }
}
