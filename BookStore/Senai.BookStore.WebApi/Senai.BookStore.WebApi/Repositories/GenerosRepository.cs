using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GenerosRepository
    {
        public string StringConexao =
            "DataSource=Localhost; initial catalog = M_Livros; User Id = sa; pwd=132";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select * from Gêneros";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(sdr["Idgenero"]),
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
            string Query = "Insert into Gêneros (Descricao) values (@Descricao);";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", genero.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
