using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class SkiResortRepository
    {
        readonly StoreManagerContext _context;
        public SkiResortRepository(StoreManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<SkiResort> GetAll()
        {
            return _context.Set<SkiResort>();
        }

        public SkiResort GetByPrimaryKey(int skiId)
        {
            return _context.Set<SkiResort>().Find(skiId);
        }
    }
}
