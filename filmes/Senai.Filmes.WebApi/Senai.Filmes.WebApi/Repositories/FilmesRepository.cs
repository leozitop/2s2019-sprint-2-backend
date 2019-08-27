﻿using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmesRepository
    {
        private string StringConexao =
           "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes; User Id=sa; pwd=132";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT F.*, G.* FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero;";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Nome = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Titulo"].ToString()
                            }
                        };
                        filmes.Add(filme);

                    }
                }
            }
            return filmes;
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes Where Filme = @Filme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Filme", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain estilo = new FilmeDomain()
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Nome = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Titulo"].ToString()
                                }
                            };
                            return estilo;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain filme)
        {
            string Query = "INSERT INTO Artistas (Titulo, IdGenero) VALUES (@Titulo,@IdGenero);";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", filme.GeneroId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}