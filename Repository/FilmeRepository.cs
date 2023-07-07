// using System.Data.SqlClient;
using Dapper;
using dotnet_dapper.Models;
using Npgsql;


namespace dotnet_dapper.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public async Task<IEnumerable<FilmeResponse>> BuscaFilmesAsync()
        {
            string sql = @"SELECT
                             f.id    Id,
                             f.nome  Nome,
                             f.ano   Ano,
                             p.nome  Produtora
                        FROM tb_filme f
                        JOIN tb_produtora p ON f.id_produtora = p.id";
            using (var con = new NpgsqlConnection(connectionString))
            {
                return await con.QueryAsync<FilmeResponse>(sql);

            }
        }

        public Task<FilmeResponse> BuscaFilmeAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> AdicionarAsync(FilmeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarAsync(FilmeRequest request, int id)
        {
            throw new NotImplementedException();
        }





        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}