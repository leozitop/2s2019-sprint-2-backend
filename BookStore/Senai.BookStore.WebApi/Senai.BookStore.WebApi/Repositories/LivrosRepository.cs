using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivrosRepository
    {
        public string StringConexao =
            "DataSource.\\SqlExpress; initial catalog = M_Livros; User Id = sa; pwd=132";

        public List<LivroDomain> Listar()
        {
            List<LivroDomain> livros = new List<LivroDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select * from Livros";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        LivroDomain livro = new LivroDomain()
                        {
                            IdLivro = Convert.ToInt32(sdr["Idlivro"]),
                            Nome = sdr["Nome"].ToString(),
                            Autor = new AutorDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdEstilo"]),
                            },
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"])
                            }
                        };
                        livros.Add(livro);
                    }
                }
            }
            return livros;
        }

        public LivroDomain BuscarPorId(int Id)
        {
            string Query = "SELECT IdLivro, Nome FROM Livros Where Livro = @Livro;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Livro", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroDomain livro = new LivroDomain()
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Nome = sdr["Nome"].ToString(),
                            };
                            return livro;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(LivroDomain livro)
        {
            string Query = "Insert into Livros (Nome, IdAutor, IdGenero) values (@Nome, @IdAutor, @IdGenero);";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", livro.Nome);
                cmd.Parameters.AddWithValue("@Email", livro.AutorId);
                cmd.Parameters.AddWithValue("@Ativo", livro.GeneroId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(LivroDomain livro)
        {
            string Query = "Update Livros set Nome = '', IdAutor = '', IdGenero = '' where IdLivro = @IdLivro;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", livro.Nome);
                cmd.Parameters.AddWithValue("@IdAutor", livro.AutorId);
                cmd.Parameters.AddWithValue("@IdGenero", livro.GeneroId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int Id)
        {
            string Query = "Delete from Livros WHERE IdLivro = @IdLivro;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Livro", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            } 
        }
    }
}
