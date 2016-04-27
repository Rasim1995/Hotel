using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;

namespace HotelClassLibrary
{
	public static class DataLayer
	{
		static string connectionString = @"Data Source=Rasim-PC\SQLEXPRESS; Initial Catalog=HOTEL; Integrated Security=True;";

        public static Dictionary<string, object> GetUserInfo(string login, string password)
		{
			Dictionary<string, object> userInfo = null;
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("GetUserInfo", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;

				SqlParameter parameter;
				parameter = new SqlParameter("@login", System.Data.SqlDbType.NVarChar);
				parameter.Value = login;
				parameter.Direction = System.Data.ParameterDirection.Input;
				command.Parameters.Add(parameter);

				parameter = new SqlParameter("@password", System.Data.SqlDbType.NVarChar);
				parameter.Value = password;
				parameter.Direction = System.Data.ParameterDirection.Input;
				command.Parameters.Add(parameter);

				parameter = new SqlParameter("@userType", System.Data.SqlDbType.NVarChar);
				parameter.Size = 50;
				parameter.Direction = System.Data.ParameterDirection.Output;
				command.Parameters.Add(parameter);

				parameter = new SqlParameter("@r", System.Data.SqlDbType.Int);
				parameter.Direction = System.Data.ParameterDirection.Output;
				command.Parameters.Add(parameter);

				try
				{
					connection.Open();
					SqlDataReader data = command.ExecuteReader();
					DbDataRecord dbInfo = null;
					if(data.HasRows)
					{
						foreach(DbDataRecord db in data)
							dbInfo = db;

						data.NextResult();
						userInfo = new Dictionary<string, object>();

						switch(command.Parameters["@userType"].Value.ToString())
						{
							case ("admin"):
								{
									userInfo.Add("userType", "admin");
									userInfo.Add("id", dbInfo.GetValue(0));
									userInfo.Add("passportNumber", dbInfo.GetValue(1));
									userInfo.Add("passportSeries", dbInfo.GetValue(2));
									userInfo.Add("surname", dbInfo.GetValue(3));
									userInfo.Add("name", dbInfo.GetValue(4));
									userInfo.Add("patronymic", dbInfo.GetValue(5));
									userInfo.Add("address", dbInfo.GetValue(6));
									userInfo.Add("phoneNumber", dbInfo.GetValue(7));
									userInfo.Add("login", dbInfo.GetValue(8));
									userInfo.Add("password", dbInfo.GetValue(9));
									break;
								}

							case "guest":
								{
									userInfo.Add("userType", "guest");
									userInfo.Add("id", dbInfo.GetValue(0));
									userInfo.Add("passportNumber", dbInfo.GetValue(1));
									userInfo.Add("passportSeries", dbInfo.GetValue(2));
									userInfo.Add("surname", dbInfo.GetValue(3));
									userInfo.Add("name", dbInfo.GetValue(4));
									userInfo.Add("patronymic", dbInfo.GetValue(5));
									userInfo.Add("address", dbInfo.GetValue(6));
									userInfo.Add("phoneNumber", dbInfo.GetValue(7));
									userInfo.Add("login", dbInfo.GetValue(8));
									userInfo.Add("password", dbInfo.GetValue(9));
									userInfo.Add("citizenship", dbInfo.GetValue(10));
									break;
								}

							case "employee":
								{
									userInfo.Add("userType", "employee");
									userInfo.Add("id", dbInfo.GetValue(0));
									userInfo.Add("passportNumber", dbInfo.GetValue(1));
									userInfo.Add("passportSeries", dbInfo.GetValue(2));
									userInfo.Add("surname", dbInfo.GetValue(3));
									userInfo.Add("name", dbInfo.GetValue(4));
									userInfo.Add("patronymic", dbInfo.GetValue(5));
									userInfo.Add("address", dbInfo.GetValue(6));
									userInfo.Add("phoneNumber", dbInfo.GetValue(7));
									userInfo.Add("login", dbInfo.GetValue(8));
									userInfo.Add("password", dbInfo.GetValue(9));
									userInfo.Add("postID", dbInfo.GetValue(10));
									break;
								}
						}
					}

				}
				catch { }

				return userInfo;
			}
		}

        public static bool AddNewGuest(int pasportNumber, int pasportSeries, string name, string surname, string patronymic,
						string address, string phoneNumber, string login, string password, int citizenship)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("AddNewGuest", connection);
				command.CommandType = CommandType.StoredProcedure;

				#region Parameters
				command.Parameters.Add(new SqlParameter("@returnValue", SqlDbType.NVarChar)
				{
					Direction = ParameterDirection.ReturnValue
				});

				command.Parameters.Add(new SqlParameter("@pasportNumber", SqlDbType.Int)
				{
					Value = pasportNumber
				});

				command.Parameters.Add(new SqlParameter("@pasportSeries", SqlDbType.Int)
				{
					Value = pasportSeries
				});

				command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar)
				{
					Value = name
				});

				command.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar)
				{
					Value = surname
				});

				command.Parameters.Add(new SqlParameter("@patronymic", SqlDbType.NVarChar)
				{
					Value = patronymic
				});

				command.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar)
				{
					Value = address
				});

				command.Parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.NVarChar)
				{
					Value = phoneNumber
				});

				command.Parameters.Add(new SqlParameter("@login", SqlDbType.NVarChar)
				{
					Value = login
				});

				command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)
				{
					Value = password
				});

				command.Parameters.Add(new SqlParameter("@citizenship", SqlDbType.NVarChar)
				{
					Value = citizenship
				});
				#endregion

				connection.Open();
				command.ExecuteReader();

				if(command.Parameters["returnValue"].Value.ToString() != string.Empty)
					throw new Exception(command.Parameters["returnValue"].ToString());
			}
			return true;
		}

        internal static bool RemoveGuest(int id)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("RemoveGuest", connection);
				command.CommandType = CommandType.StoredProcedure;

				#region Parameters
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)
				{
					Direction = ParameterDirection.Input,
					Value = id
				}); 
				#endregion

				connection.Open();
				command.ExecuteReader();
			}
			return true;
		}

        public static void ByARoom(int idRoom, int idGuest, DateTime checkTheDate, DateTime checkOutDate)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("ByARoom", connection);
				command.CommandType = CommandType.StoredProcedure;

				#region Parameters
				command.Parameters.Add(new SqlParameter("@idRoom", SqlDbType.Int)
				{
					Value = idRoom
				});

				command.Parameters.Add(new SqlParameter("@idGuest", SqlDbType.Int)
				{
					Value = idGuest
				});

				command.Parameters.Add(new SqlParameter("@checkTheDate", SqlDbType.DateTime)
				{
					Value = checkTheDate
				});

				command.Parameters.Add(new SqlParameter("@checkOutdate", SqlDbType.DateTime)
				{
					Value = checkOutDate
				});
				#endregion

				connection.Open();
				command.ExecuteReader();
			}
		}

        internal static void CancelPurchase(int idPurchase)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CancelPurchase", connection);
				command.CommandType = CommandType.StoredProcedure;

				#region Parameters
				command.Parameters.Add(new SqlParameter("@idPurchase", SqlDbType.Int)
				{
					Value = idPurchase
				});
				#endregion

				connection.Open();
				command.ExecuteReader();
			}
		}

        public static ArrayList GetAllRooms()
		{
			ArrayList listRooms=null;
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("GetAllRooms", connection);
				command.CommandType = CommandType.StoredProcedure;

				connection.Open();
				SqlDataReader data =  command.ExecuteReader();

				if(data.HasRows)
				{
					listRooms = new ArrayList();
                    foreach (DbDataRecord d in data)
                        //listRooms.Add(new Room() { Id = d.GetInt32(0), Number = d.GetInt32(1), IdCategory=d.GetInt32(2) });
                        listRooms.Add(d);
				}

			}
			return listRooms;
		}

        public static ArrayList GetPurchases(int idKlient)
		{
			ArrayList listRooms = null;
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("GetPurchases", connection);
				command.CommandType = CommandType.StoredProcedure;

				#region Parameters
				command.Parameters.Add(new SqlParameter("@idPurchase", SqlDbType.Int)
				{
					Value = idKlient
				});
				#endregion

				connection.Open();
				SqlDataReader data = command.ExecuteReader();

				if(data.HasRows)
				{
					listRooms = new ArrayList();
					foreach(DbDataRecord d in data)
						listRooms.Add(d);
				}

			}
			return listRooms;
		}

        public static ArrayList GetAllCategories()
        {
            ArrayList allCategories=null;
            ArrayList l = new ArrayList();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Select * from Categories", connection);
                command.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    allCategories = new ArrayList();
                    foreach (DbDataRecord d in data)
                        allCategories.Add(d);
                }
            }
            return allCategories;
        }
	}
}
