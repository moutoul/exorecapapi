using exorecapapi.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exorecapapi.Repositories
{
    public class JeuxRepository : IRepository<JeuxPOCO, int>
    {
        private string _cnstr;
        public JeuxRepository(string cnstr)
        {
            _cnstr = cnstr;
        }
        public int Add(JeuxPOCO obj)
        {
            int id;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cnstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Jeux OUTPUT inserted.Id VALUES (  @Titre, @AneeSortie,@Note,@Descriptif,@GenreId)";

                      
                        cmd.Parameters.AddWithValue("Titre", obj.Titre);
                        cmd.Parameters.AddWithValue("AneeSortie", obj.AnneeSortie);
                        cmd.Parameters.AddWithValue("Note", obj.Note);
                        cmd.Parameters.AddWithValue("Descriptif", obj.Descriptif);
                        cmd.Parameters.AddWithValue("GenreId", obj.GenreId);

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

        public JeuxPOCO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JeuxPOCO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
