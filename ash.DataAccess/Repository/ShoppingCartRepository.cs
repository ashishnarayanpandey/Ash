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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDataContext _db;


        public ShoppingCartRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }
    }
}
