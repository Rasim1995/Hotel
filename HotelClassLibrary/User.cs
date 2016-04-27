using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelClassLibrary
{
	public abstract class User
	{
		#region Private
		protected int id;
		protected int passportNumber;
		protected int passportSeries;
		protected string name;
		protected string surname;
		protected string patronymic;
		protected string address;
		protected string phoneNumber;
		protected string login;
		protected string password;
		#endregion

		#region Properties
		abstract public int Id
		{
			get;
		}
		abstract public int PassportNumber
		{
			get;
			set;
		}
		abstract public int PassportSeries
		{
			get;
			set;
		}
		abstract public string Name { get; set; }
		abstract public string Surname
		{
			get;
			set;
		}
		abstract public string Patronymic
		{
			get;
			set;
		}
		abstract public string Address
		{
			get;
			set;
		}
		abstract public string PhoneNumber
		{
			get;
			set;
		}
		abstract public string Login
		{
			get;
			set;
		}
		abstract public string Password
		{
			get;
			set;
		} 
		#endregion

		public User() { }
		public User(int id, int passportNumber, int passportSeries, 
			string name, string surname, string patronymic, 
			string address, string phoneNumber, string login, string password)
		{
			this.id = id;
			this.passportNumber = passportNumber;
			this.passportSeries = passportSeries;
			this.name = name;
			this.surname = surname;
			this.patronymic = patronymic;
			this.address = address;
			this.phoneNumber = phoneNumber;
			this.login = login;
			this.password = password;
		}
	}
}
