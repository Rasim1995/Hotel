using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelClassLibrary
{
	public class Guest : User
	{
		int citizenship;
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
		public int Citizenship
		{
			get { return citizenship; }
			set { citizenship = value; }
		}

		public Guest() { }
		public Guest(DataLayer data, int id, int passportNumber, int passportSeries, string name, string surname, string patronymic,
						string address, string phoneNumber, string login, string password, int citizenship)
			: base(data, id, passportNumber, passportSeries, name, surname, patronymic, address, phoneNumber, login, password)
		{
			this.citizenship = citizenship;
		}

		public void BuyARoom(int idRoom, DateTime checkTheDate, DateTime checkOutDate)
		{
			data.ByARoom(idRoom, Id, checkTheDate, checkOutDate);
		}
		public void CancelPurchase(int idPurchase)
		{
			data.CancelPurchase(idPurchase);
		}
	}
}
