using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez06_Task_edicola.Models.DAL
{
    internal class GiocattoloDao : IDaoLettura<Giocattolo>, IDaoScrittura<Giocattolo>
    {
        public static GiocattoloDao? Instance;

        public static GiocattoloDao GetInstance()
        {
            if (Instance == null)
                Instance = new GiocattoloDao();
            return Instance;
        }
        private GiocattoloDao() { }



        public List<Giocattolo> GetAll()
        {
            List<Giocattolo> risultato = new List<Giocattolo>();

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT giocattoloId,nome,materiale,etaMin,prezzo,codUniGio FROM Giocattolo";

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Giocattolo giocattolo = new Giocattolo()
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Materiale = reader.GetString(2),
                            EtaMin = reader.GetInt32(3),
                            Prezzo = (double)reader.GetDecimal (4),
                            CodUniGio = reader.GetString(5),
                        };
                        risultato.Add(giocattolo);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                { conn.Close(); }
            }
            return risultato;

        }

        public Giocattolo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Giocattolo obj)
        {
            bool risultato = false;
            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Giocattolo(nome, materiale ,etaMin , prezzo) VALUES (@nom,@materiale,@etaMin,@prezzo)";
                cmd.Parameters.AddWithValue("@nom", obj.Nome);
                cmd.Parameters.AddWithValue("@materiale", obj.Materiale);
                cmd.Parameters.AddWithValue("@etaMin", obj.EtaMin);
                cmd.Parameters.AddWithValue("@prezzo", obj.Prezzo);
                try
                {
                    conn.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            return risultato;
        }

        public bool Update(Giocattolo t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
