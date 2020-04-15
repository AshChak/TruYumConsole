using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public class Cart
    {
		private List<MenuItem> menuItemList;

		public List<MenuItem> MenuItemList
		{
			get { return menuItemList; }
			set { menuItemList = value; }
		}

		private double total;

		public double Total
		{
			get { return total; }
			set { total = value; }
		}

		public Cart()
		{
		}

		public Cart(List<MenuItem> menuItemList, double total)
		{
			MenuItemList = menuItemList;
			Total = total;
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
	}
}
