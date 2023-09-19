using CupcakeApi702.Models;
using Microsoft.Data.SqlClient;

namespace CupcakeApi702.Database
{
    public class DbContext
    {
        private readonly SqlConnection connection;

        public DbContext(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        public List<Cupcake> GetCupcakes()
        {
            List<Cupcake> cupcakes = new List<Cupcake>();
            string sqlText = "SELECT [Id], [Name], [ImageName], [Description], [Price] FROM [dbo].[Cupcakes]";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sqlText;

            // Open connection to database
            connection.Open();

            // Execute the SQL in database
            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate through the result set.
            while (reader.Read())
            {
                Cupcake cupcake = new Cupcake();
                cupcake.Id = reader.GetInt32(0);
                cupcake.Name = reader.GetString(1);
                cupcake.ImageName = reader.GetString(2);
                cupcake.Description = reader.GetString(3);
                cupcake.Price = reader.GetDecimal(4);

                cupcakes.Add(cupcake);
            }

            // Close the connection
            connection.Close();

            return cupcakes;
        }
    }
}
