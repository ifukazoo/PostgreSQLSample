using Npgsql;
using System;
using System.Configuration;
using System.Data.Common;

namespace PostgreSQLSample
{
    class Program
    {

        static void Main(string[] args)
        {
            var connString = ConfigurationManager.ConnectionStrings["db"]?.ConnectionString;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                for (;;)
                {
                    var input = Console.ReadLine();
                    input.Trim();
                    if (input.ToLower().StartsWith("q"))
                    {
                        break;
                    }
                    if (input.Length == 0)
                    {
                        continue;
                    }
                    using (var cmd = new NpgsqlCommand(input, conn))
                    {
                        try
                        {
                            if (input.ToLower().StartsWith("select"))
                            {
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var sep = "";
                                        for (var i = 0; i < reader.FieldCount; i++)
                                        {
                                            Console.Write(sep + reader.GetValue(i).ToString());
                                            sep = " ";
                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                            else
                            {
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("success and auto commit cmd[" + input + "]");
                            }
                        }
                        catch (DbException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }
    }
}
