using exorecapapi.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            int id;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cnstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Genre OUTPUT inserted.Id VALUES ( @Nom)";



                        cmd.Parameters.AddWithValue("Nom", obj.Nom);
                        


                        id = (int)cmd.ExecuteScalar();
                    }
                    conn.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
