using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.NovaPasta
{
    public class EstilosRepository
    {
        List<EstilosDomain> estilos = new List<EstilosDomain>()
                {
                new EstilosDomain { IdEstilo = 1,   Nome = "Rock"}
                ,new EstilosDomain { IdEstilo = 2,  Nome = "Pop"}
    };
       

        private string StringConexao =
           "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132;";

        public void Cadastrar(EstilosDomain estilo)
        {
            string Query = "INSERT INTO Estilos (Nome) Values ('" + estilo.Nome + "')";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", estilo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public EstilosDomain BuscarPorId(int Id)
            {
                string Query = "SELECT IdEstilo, Nome FROM Estilos Where Estilo = @EstiloMusical";

                using(SqlConnection con = new SqlConnection(StringConexao))
                    {
                        con.Open();
                        SqlDataReader sdr;

                        using (SqlCommand cmd = new SqlCommand(Query, con))
                            {
                                cmd.Parameters.AddWithValue("@EstiloMusical", Id);
                                sdr = cmd.ExecuteReader();

                                if(sdr.HasRows)
                                    {
                                        while(sdr.Read())
                                        {
                                            EstilosDomain estilo = new EstilosDomain()
                                            {
                                                IdEstilo = Convert.ToInt32(sdr["IdEstilo"]),
                                                Nome = sdr["Nome"].ToString()
                                            };
                            return estilo;
                                        }
                                    }
                    return null;
                            }
                    }
            }


        public List<EstilosDomain> Listar()
        {
            List<EstilosDomain> estilos = new List<EstilosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdEstilo, Nome FROM Estilos";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EstilosDomain estilo = new EstilosDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstilo"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    };
                }
            }
            return estilos;

        }

        public void Alterar(EstilosDomain estilosDomain)
        {
            string Query = "UPDATE Estilos SET Nome = '' WHERE IdEstilo = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", estilosDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estilosDomain.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int Id)
        {
            string Query = "DELETE FROM Estilos WHERE IdEstilo = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
