using exorecapapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exorecapapi.Repositories
{
    public class GenreRepository : IRepository<GenrePOCO, int>
    {
        private string _cnstr;
        public GenreRepository(string cnstr)
        {
            _cnstr = cnstr;
        }
        public int Add(GenrePOCO obj)
        {
            throw new NotImplementedException();
        }

        public GenrePOCO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenrePOCO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
