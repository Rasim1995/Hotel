using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelClassLibrary
{
	public static class Hotel
	{
		static DataLayer data = new DataLayer();
		public static event EventHandler EnterGuest, EnterEmployee, EnterAdministrator;

		static public void Authorization(string login, string password)
		{
			Dictionary<string, object> userInfo = data.GetUserInfo(login, password);

			if(userInfo == null)
				throw new Exception("Неверный логин и пароль");

			switch(userInfo["userType"].ToString())
			{
				case "guest":
					if(EnterGuest!=null)
					EnterGuest(new Guest
					(
						data,
						(int)userInfo["id"],
						(int)userInfo["passportNumber"],
						(int)userInfo["passportSeries"],
						(string)userInfo["name"],
						(string)userInfo["surname"],
						(string)userInfo["patronymic"],
						(string)userInfo["address"],
						(string)userInfo["phoneNumber"],
						(string)userInfo["login"],
						(string)userInfo["password"],
						(int)userInfo["citizenship"]
					), null);
					break;

				case "employee":
					EnterEmployee(new Employee
					(
						data,
						(int)userInfo["id"],
						(int)userInfo["passportNumber"],
						(int)userInfo["passportSeries"],
						(string)userInfo["name"],
						(string)userInfo["surname"],
						(string)userInfo["patronymic"],
						(string)userInfo["address"],
						(string)userInfo["phoneNumber"],
						(string)userInfo["login"],
						(string)userInfo["password"],
						(int)userInfo["post"]
					), null);
					break;

				case "admin":
					EnterAdministrator(new Admin
					(
						data,
						(int)userInfo["id"],
						(int)userInfo["passportNumber"],
						(int)userInfo["passportSeries"],
						(string)userInfo["name"],
						(string)userInfo["surname"],
						(string)userInfo["patronymic"],
						(string)userInfo["address"],
						(string)userInfo["phoneNumber"],
						(string)userInfo["login"],
						(string)userInfo["password"]
					), null);
					break;
			}
		}
		static public bool RegistrationGuest(int pasportNumber, int pasportSeries, string name, string surname, string patronymic,
									  string address, string phoneNumber, string login, string password, int citizenship)
		{
			if(pasportNumber < 1000 || pasportNumber > 999999)
				throw new Exception("Диапазон номера паспорта должен лежать в диапазоне 1000 - 9999999");

			if(pasportSeries < 1000 || pasportSeries > 9999999)
				throw new Exception("Диапазон серии паспорта должен лежать в диапазоне 1000 - 9999999");

			if(name == string.Empty)
				throw new Exception("Поле \"Имя\" не должен быть пустым");
			if(name.Length > 50)
				throw new Exception("Число знаков в поле \"Имя\" не может превышать 50");

			if(surname == string.Empty)
				throw new Exception("Поле \"Фамилия\" не должен быть пустым");
			if(surname.Length > 50)
				throw new Exception("Число знаков в поле \"Фамилия\" не может превышать 50");

			if(patronymic == string.Empty)
				throw new Exception("Поле \"Отчество\" не должен быть пустым");
			if(patronymic.Length > 50)
				throw new Exception("Число знаков в поле \"Отчество\" не может превышать 50");

			return data.AddNewGuest(pasportNumber, pasportSeries, name, surname, patronymic, address, phoneNumber, login, password, citizenship);
		}
		static public bool RemoveGuest(int id)
		{
			return data.RemoveGuest(id);
		}
		
	}
}
