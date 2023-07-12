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
            JeuxPOCO JeuxRecupere = null;


            using (SqlConnection oConn = new SqlConnection(_cnstr))
            {
                try
                {
                    oConn.Open();
                   
                    using (SqlCommand ocmd = oConn.CreateCommand())
                    {
                        //3 -  je récupère les données
                        string requete = "Select * FROM Jeux WHERE ID = @Id";
                        ocmd.CommandText = requete;
                        ocmd.Parameters.AddWithValue("section_id", id);
                        SqlDataReader oDr = ocmd.ExecuteReader();
                        if (oDr.Read())
                        {
                            JeuxRecupere = new JeuxPOCO();
                            
                            JeuxRecupere.Id = (int)oDr["ID"];
                            if (oDr["Section_name"] != DBNull.Value)
                            {
                                JeuxRecupere.Titre = (string)oDr["Titre"];
                            }
                            if (oDr["AnneeSortie"] != DBNull.Value)
                            {
                                JeuxRecupere.AnneeSortie = (int)oDr["AnneeSortie"];
                            }
                            if (oDr["Note"] != DBNull.Value)
                            {
                                JeuxRecupere.Note = (float)oDr["Note"];
                            }
                            if (oDr["Descriptif"] != DBNull.Value)
                            {
                                JeuxRecupere.Descriptif = (string)oDr["Descriptif"];
                            }
                            if (oDr["GenreID"] != DBNull.Value)
                            {
                                JeuxRecupere.GenreId = (int)oDr["GenreID"];
                            }
                        }
                        oDr.Close();

                    }

                    oConn.Close();
                    return JeuxRecupere;
                }
                catch (Exception)
                {

                    throw;
                }
            }
           
        }
       
        public IEnumerable<JeuxPOCO> GetAll()
        {
            List<JeuxPOCO> JeuxRecupere = new List<JeuxPOCO>();


            using (SqlConnection oConn = new SqlConnection(_cnstr))
            {
                try
                {
                    /*1- Connect */
                    oConn.Open();
                    //2- je prépare ma requête
                    using (SqlCommand ocmd = oConn.CreateCommand())
                    {
                        //3 -  je récupère les données
                        string requete = "Select * FROM Jeux";
                        ocmd.CommandText = requete;


                        SqlDataReader oDr = ocmd.ExecuteReader();
                        while (oDr.Read())
                        {
                            JeuxPOCO JeuxRecuper = new JeuxPOCO();

                            JeuxRecuper.Id = (int)oDr["ID"];
                            if (oDr["Section_name"] != DBNull.Value)
                            {
                                JeuxRecuper.Titre = (string)oDr["Titre"];
                            }
                            if (oDr["AnneeSortie"] != DBNull.Value)
                            {
                                JeuxRecuper.AnneeSortie = (int)oDr["AnneeSortie"];
                            }
                            if (oDr["Note"] != DBNull.Value)
                            {
                                JeuxRecuper.Note = (float)oDr["Note"];
                            }
                            if (oDr["Descriptif"] != DBNull.Value)
                            {
                                JeuxRecuper.Descriptif = (string)oDr["Descriptif"];
                            }
                            if (oDr["GenreID"] != DBNull.Value)
                            {
                                JeuxRecuper.GenreId = (int)oDr["GenreID"];
                            }
                            //4 -  je mets les données dans mon object
                            //Mapping
                            // monRetour.Add(Map(oDr));

                        }

                        oDr.Close();

                    }

                    oConn.Close();
                    return JeuxRecupere;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //5 je retourne l'objet 
        }
    }
}
