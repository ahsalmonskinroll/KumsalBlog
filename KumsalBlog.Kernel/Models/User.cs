using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumsalBlog.Kernel.Models
{
    public class User : BaseEntity     //base entitiyden miras alıcak
    {
		private string userName;

		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		private string mailAddress;

		public string MailAddress
		{
			get { return mailAddress; }
			set { mailAddress = value; }
		}

		private string comment;

		public string Comment
		{
			get { return comment; }
			set { comment = value; }
		}

		private int rating;

		public int Rating
		{
			get { return rating; }
			set { rating = value; }
		}


	}
}
