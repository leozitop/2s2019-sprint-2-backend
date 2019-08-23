using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutoresRepository
    {
        public string StringConexao = 
            "DataSource.\\SqlExpress; initial catalog=M_Livros; User Id=sa; pwd=132";

        public List<AutorDomain> Listar()
        {
            List<AutorDomain> autores = new List<AutorDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select * from Autores";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        AutorDomain autor = new AutorDomain()
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        autores.Add(autor);
                    }
                }
            }
            return autores;
        }

        public void Cadastrar(AutorDomain autor)
        {
            string Query = "Insert into Autores (Nome, Email, Ativo, DataNascimento) values (@Nome, @Email, @Ativo, @DataNascimento);";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Email", autor.Email);
                cmd.Parameters.AddWithValue("@Ativo", autor.Ativo);
                cmd.Parameters.AddWithValue("@DataNscimento", autor.DataNscimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
