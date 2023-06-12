using ash.DataAccess.Data;
using ash.DataAccess.Repository.IRepository;
using Ash.Models;
using Ash.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDataContext _db;


        public OrderHeaderRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }
        
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }
    }
}
