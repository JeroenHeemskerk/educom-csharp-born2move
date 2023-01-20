using System.Data.SqlClient;

namespace BornToMove
{
    public class MoveDAL
    {
        // class variables
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\vince\\source\\repos\\educom-csharp-born2move\\BornToMove\\BornToMove\\Data\\born2move.mdf;Integrated Security=True";

        public List<Move> GetAllMoves()
        {
            List<Move> movesList = new List<Move>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, name, sweatRate FROM move", conn);

                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    movesList.Add(new Move
                    {
                        Id = Convert.ToInt32(data[0]),
                        Name = data[1].ToString(),
                        SweatRate = Convert.ToInt32(data[2])
                    });
                }
            }

            return movesList;
        }

        public List<Move> GetMove(int Id)
        {
            List<Move> moveList = new List<Move>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM move WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    moveList.Add(new Move
                    {
                        Id = Convert.ToInt32(data[0]),
                        Name = data[1].ToString(),
                        Description = data[2].ToString(),
                        SweatRate = Convert.ToInt32(data[3])
                    });
                }
            }

            return moveList;
        }

        public void SetMove(string name, string description, int sweatRate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO move (name, description, sweatRate) VALUES (@name, @description, @sweatRate)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@sweatRate", sweatRate);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
