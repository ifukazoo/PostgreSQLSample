using System;
using System.Text;
using Npgsql;

namespace PosgresSQLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // 雪が２０センチ以上の日
                using (var cmd = new NpgsqlCommand("SELECT * FROM matsumoto_temp where snow >= 20 order by month", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var sb = new StringBuilder();
                    while (reader.Read())
                    {
                        sb.Append(reader.GetDate(0)).Append("\t")
                          .Append(reader.GetDouble(1)).Append("\t")
                          .Append(reader.GetInt32(2)).Append("\t")
                          .Append(reader.GetInt32(3)).Append("\t")
                          .Append(reader.GetDouble(4)).Append("\t")
                          .Append(reader.GetInt32(5)).Append("\t")
                          .Append(reader.GetInt32(6)).Append("\t")
                          .Append(reader.GetInt32(7)).Append("\t")
                          .Append(reader.GetInt32(8)).Append("\t")
                          .Append(reader.GetInt32(9)).Append("\t")
                          .Append(reader.GetInt32(10)).Append("\t")
                          .AppendLine();
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}
