using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace IC6.TutorialCQRS.Queries
{
    public class QueriesService : IQueriesService
    {
        private readonly string _connectionString;

        public QueriesService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<IEnumerable<int>> GetAllPostId()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                return await conn.QueryAsync<int>("SELECT Id FROM dbo.Posts;");
            }
        }
    }
}
