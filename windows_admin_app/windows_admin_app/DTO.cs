using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windows_admin_app
{
    #region AUTHOR DTO
    public class clsAuthor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public List<clsBook> BookList { get; set; }
    }
    #endregion

    #region BOOK DTO
    public class clsBook
    {
        public string Isbn { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime EditDate { get; set; }
        public string Genre { get; set; }
        public string Category { get; set; }
        public string AuthorName {get; set;}


        // AUTHOR FORM DATA FORMATING
        public override string ToString()
        {
            return 
                string.Format(" {0, -28}", Title) +
                string.Format("{0, -9}", Quantity) +
                "$" + string.Format("{0, 0}", Price);
        }

        // FACTORY METHOD
        public static clsBook NewBook(string prChoice)
        {
            return new clsBook() { Type = prChoice };
        }

    }

    #endregion

    #region ORDER DTO
    public class clsOrder
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Isbn { get; set; }
        public List<clsOrder> OrderList { get; set; }

        // AUTHOR FORM DATA FORMATING
        public override string ToString()
        {
            return 
                string.Format(" {0, -8}", Number) + 
                string.Format("{0, -22}", Name) + 
                string.Format("{0, -31}", Email) +
                string.Format("{0, -16}", OrderDate.ToShortDateString()) +
                string.Format("{0, -16}", Isbn) +
                "$" + string.Format("{0, -10}", Price) +
                string.Format("{0, -6}", Quantity) +
                "$" + string.Format("{0, 0}", (Quantity * Price));
        }
    }

    #endregion

}
