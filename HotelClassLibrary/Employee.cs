using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelClassLibrary
{
	public class Employee:User
	{
		#region private
		int post;
		#endregion
		public override int Id
		{
			get { return id; }
		}
		public override int PassportNumber
		{
			get
			{
				return passportNumber;
			}

			set
			{
				passportNumber = value;
			}
		}
		public override int PassportSeries
		{
			get
			{
				return passportSeries;
			}

			set
			{
				passportSeries = value;
			}
		}
		public override string Name
		{
			get { return name; }
			set { name = value; }
		}
		public override string Surname
		{
			get { return surname; }
			set { surname = value; }
		}
		public override string Patronymic
		{
			get
			{
				return patronymic;
			}

			set
			{
				patronymic = value;
			}
		}
		public override string Address
		{
			get
			{
				return address;
			}

			set
			{
				address = value;
			}
		}
		public override string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}

			set
			{
				phoneNumber = value;
			}
		}
		public override string Login
		{
			get { return login; }
			set { login = value; }
		}
		public override string Password
		{
			get { return password; }
			set { password = value; }
		}
		public int Post
		{
			get { return post; }
			set { post = value; }
		}
		public Employee(int id, int passportNumber, int passportSeries, string name, string surname, string patronymic,
						string address, string phoneNumber, string login, string password, int post)
			: base(id, passportNumber, passportSeries, name, surname, patronymic, address, phoneNumber, login, password)
		{
			this.post = post;
		}


	}
}
