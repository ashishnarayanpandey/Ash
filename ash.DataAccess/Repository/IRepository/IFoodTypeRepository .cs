using Ash.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<Food>
    {
        void Update(Food obj);
    }
}
