using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez06_Task_edicola.Models.DAL
{
    internal class RivistaDao : IDaoLettura<Rivista>, IDaoScrittura<Rivista>
    {
        public static RivistaDao? Instance;
        public static RivistaDao GetInstance()
        {
            if (Instance == null) 
                Instance = new RivistaDao(); 
            return Instance;
        }
        private RivistaDao() { }



        public List<Rivista> GetAll()
        {
            List<Rivista> risultato =new List<Rivista>();

            using (SqlConnection conn = new SqlConnection(Config.credenziali)) 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT rivistaId, titolo,casaEditrice,codUniRiv FROM Rivista";

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Rivista rivista = new Rivista()
                        {
                            Id = reader.GetInt32(0),
                            Titolo = reader.GetString(1),
                            CasaEditrice = reader.GetString(2),
                            CodUniRiv=reader.GetString(3),
                        };
                        risultato.Add(rivista);
                    }

                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally 
                { conn.Close(); }
            }
            return risultato;

        }

        public Rivista GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rivista obj)
        {
              bool risultato = false;
                using (SqlConnection conn = new SqlConnection(Config.credenziali))
                {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Rivista(titolo, casaEditrice) VALUES (@tit,@casaEd)";
                cmd.Parameters.AddWithValue("@tit", obj.Titolo);
                cmd.Parameters.AddWithValue("@casaEd", obj.CasaEditrice);
                try
                {
                    conn.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        risultato = true;
                  
                }catch(Exception ex) 
                { Console.WriteLine(ex.Message);
                }
                finally
                { 
                    conn.Close(); 
                }

            }
            return risultato;
        }

        public bool Update(Rivista t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
