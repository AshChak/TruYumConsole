using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public class MenuItem
    {
		private long id;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		private String name;

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

		private float price;

		public float Price
		{
			get { return price; }
			set { price = value; }
		}

		private Boolean active;

		public Boolean Active
		{
			get { return active; }
			set { active = value; }
		}

		private DateTime dateOfLaunch;

		public DateTime DateOfLaunch
		{
			get { return dateOfLaunch; }
			set { dateOfLaunch = value; }
		}

		private string category;

		public string Category
		{
			get { return category; }
			set { category = value; }
		}

		private bool freeDelivery;

		public bool FreeDelivery
		{
			get { return freeDelivery; }
			set { freeDelivery = value; }
		}

		public MenuItem()
		{
		}

		public MenuItem(long id, string name, float price, bool active, DateTime dateOfLaunch, string category, bool freeDelivery)
		{
			Id = id;
			Name = name;
			Price = price;
			Active = active;
			DateOfLaunch = dateOfLaunch;
			Category = category;
			FreeDelivery = freeDelivery;
		}

		public override string ToString()
		{
			return $"{Id}. {Name} ({Category}) - {Price}\n" +
				$"\tFree Delivery: {FreeDelivery} | Launch Date: {DateOfLaunch.ToString("d")} | Active: {Active}";
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
	}
}
