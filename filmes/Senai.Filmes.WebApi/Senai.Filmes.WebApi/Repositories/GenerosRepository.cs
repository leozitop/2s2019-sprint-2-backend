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
        List<GeneroDomain> generos = new List<GeneroDomain>()
        {
            new GeneroDomain { IdGenero = 1,   Nome = "Comédia"}
            ,new GeneroDomain { IdGenero = 2,  Nome = "Ficção"}
        };


        private string StringConexao =
           "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select IdGenero, Nome from Generos";
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

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "Insert into Generos (Nome) Values ('" + genero.Nome + "')";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                cmd.Parameters.AddWithValue("Nome", genero.Nome);
                con.Open();
            }
        }

        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = ;
        }
    }
}
