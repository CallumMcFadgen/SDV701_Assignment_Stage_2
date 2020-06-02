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
        public float? Desc { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime EditDate { get; set; }
        public float? Genre { get; set; }
        public float? Category { get; set; }
        public string AuthorName { get; set; }
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
    }
    #endregion





}
