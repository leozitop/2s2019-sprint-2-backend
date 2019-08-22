using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GenerosRepository
    {

        private string StringConexao =
           "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select IdGenero, Nome from Generos;";
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            string Query = "SELECT IdGenero, Nome FROM generos Where Genero = @Genero;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Genero", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "Insert into Generos (Nome) Values ('@Nome');";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                con.Open();
            }
        }

        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Estilos SET Nome = '' WHERE IdGenero = @IdGenero;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", generoDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int Id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
