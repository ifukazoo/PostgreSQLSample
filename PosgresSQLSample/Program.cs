using Npgsql;
using System;
using System.Configuration;
using System.Data.Linq;
using System.Text;

namespace PosgresSQLSample
{
    class Program
  {
    class TempRecord
    {
      // 列   |      型      |  修飾語
      // --------+--------------+----------
      // month  | date         | not null
      // max    | numeric(3,1) |
      // max_q  | integer      |
      // max_v  | integer      |
      // min    | numeric(3,1) |
      // min_q  | integer      |
      // min_v  | integer      |
      // snow   | integer      |
      // snow_e | integer      |
      // snow_q | integer      |
      // snow_v | integer      |
      internal DateTime month { get; set; }
      internal Double max { get; set; }
      internal int max_q { get; set; }
      internal int max_v { get; set; }
      internal Double min { get; set; }
      internal int min_q { get; set; }
      internal int min_v { get; set; }
      internal int snow { get; set; }
      internal int snow_e { get; set; }
      internal int snow_q { get; set; }
      internal int snow_v { get; set; }
    }

    static void Main(string[] args)
    {
      var connString = ConfigurationManager.ConnectionStrings["db"]?.ConnectionString;
      using (var conn = new NpgsqlConnection(connString))
      {
        conn.Open();

        // 雪が２０センチ以上の日
        using (var context = new DataContext(conn))
        {
          foreach (var record in context.ExecuteQuery<TempRecord>("SELECT * FROM matsumoto_temp where snow >= 20 order by month"))
          {
            var sb = new StringBuilder();
            sb.Append(record.month).Append("\t")
              .Append(record.max).Append("\t")
              .Append(record.max_q).Append("\t")
              .Append(record.max_v).Append("\t")
              .Append(record.min).Append("\t")
              .Append(record.min_q).Append("\t")
              .Append(record.min_v).Append("\t")
              .Append(record.snow).Append("\t")
              .Append(record.snow_e).Append("\t")
              .Append(record.snow_q).Append("\t")
              .Append(record.snow_v).Append("\t")
              .AppendLine();
            Console.WriteLine(sb.ToString());
          }
        }
      }
    }
  }
}
