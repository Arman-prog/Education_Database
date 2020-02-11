using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Education_Database.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : new()
    {
        private readonly string connectionString = ConfigurationManager
                                                 .ConnectionStrings["MyConnection"]
                                                 .ConnectionString;
        protected abstract string Sqlexpression { get; }

        public List<TModel> ToList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Sqlexpression, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                List<TModel> models = new List<TModel>();
                while (dataReader.Read())
                {
                    models.Add(dataReader.SqlToModel<TModel>());
                }

                dataReader.Close();
                return models;
            }

        }

    }
}
