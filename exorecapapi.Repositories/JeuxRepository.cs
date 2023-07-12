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
                        cmd.CommandText = "INSERT INTO Section OUTPUT inserted.section_id VALUES ( @section_id, @sectionname, @delegateid)";

                        cmd.Parameters.Add("@section_id", System.Data.SqlDbType.VarChar).Value = obj.Section_Id;

                        cmd.Parameters.AddWithValue("sectionname", obj.Section_Name);
                        cmd.Parameters.AddWithValue("delegateid", obj.Delegate_id);


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
