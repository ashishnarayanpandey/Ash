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
    public class ApplicationUsersRepository : Repository<ApplicationUsers>, IApplicationUsersRepository
    {
        private readonly ApplicationDataContext _db;


        public ApplicationUsersRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
            
        }
       
    }
}
