using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumsalBlog.Kernel.Models
{
	public class BaseEntity //miras alacağımız class. her entity girişi için lazım. prop yaz 2 tab yap.
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private DateTime createdDate;

		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}

	}
}
