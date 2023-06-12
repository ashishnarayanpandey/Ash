using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext _db;

        public UnitOfWork(ApplicationDataContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Food = new FoodTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            OrderHeader  = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            ApplicationUsers = new ApplicationUsersRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository Food { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IApplicationUsersRepository ApplicationUsers { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
