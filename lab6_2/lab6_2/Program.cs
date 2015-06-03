using System;
using System.Data;
using System.Data.SqlClient;

namespace lab6_2
{
	class Program
	{
		static void Main(string[] args)
		{
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = "Data Source=DASHA;Initial Catalog=Maps;Integrated Security=True";
			Console.Write("Введите должность: ");
			try {
				cn.Open();
				SqlCommand command = cn.CreateCommand();
				command.CommandText = "select name_surname from Workers where position=@position";
				SqlParameter positionParameter = command.Parameters.Add("@position", SqlDbType.VarChar);
				positionParameter.Value = Console.ReadLine();
				using (SqlDataReader reader = command.ExecuteReader()) {
					Console.WriteLine("name_surname");
					Console.WriteLine("------------");
					while (reader.Read()) {
						Console.WriteLine(reader.GetString(0));
					}
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			} finally {
				cn.Close();
			}
			Console.ReadKey();
		}
	}
}
