using EmployeeManagementSystem.Core.IRepositories;
using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EF.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            if (item == null)
            {
                return 0;
            }
            _context.Set<T>().Remove(item);
            return 1;
        }

       public async Task<IEnumerable<T>>GetAllData()
       {
            return _context.Set<T>().ToList();
       }

        public async Task<T> GetById(int id)
        {
            var item = _context.Set<T>().Find(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }  
}
