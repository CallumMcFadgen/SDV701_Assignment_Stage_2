using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_hosting_service
{
    public class StoreController : System.Web.Http.ApiController
    {
        #region PARAMETER CONFIGURATION

        private Dictionary<string, object> prepareAuthorParameters(clsAuthor prAuthor)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("Name", prAuthor.Name);
            par.Add("Email", prAuthor.Email);
            par.Add("JoinDate", prAuthor.JoinDate);
            return par;
        }

        #endregion

        #region DATA FORMATTING

        private clsBook formatBookData(DataRow prDataRow)
        {
            Console.Write("formatBookData called" + "\n" + "\n");

            return new clsBook()
            {
                Isbn = Convert.ToChar(prDataRow["isbn_number"]),
                Type = Convert.ToString(prDataRow["type"]),
                Title = Convert.ToString(prDataRow["title"]),
                Desc = prDataRow["Description"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["Description"]),
                Price = Convert.ToDecimal(prDataRow["price"]),
                Quantity = Convert.ToInt32(prDataRow["quantity"]),
                EditDate = Convert.ToDateTime(prDataRow["edit_date"]),
                Genre = prDataRow["genre"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["genre"]),
                Category = prDataRow["category"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["category"]),
                AuthorName = Convert.ToString(prDataRow["author_name"])
            };
        }

        //private clsOrder formatOrderData(DataRow prDataRow)
        //{
        //    return new clsOrder()
        //    {
        //        Number = Convert.ToInt32(prDataRow["Number"]),
        //        Name = Convert.ToString(prDataRow["Name"]),
        //        Email = Convert.ToString(prDataRow["Email"]),
        //        OrderDate = Convert.ToDateTime(prDataRow["OrderDate"]),
        //        Price = Convert.ToDecimal(prDataRow["Price"]),
        //        Quantity = Convert.ToInt32(prDataRow["Quantity"]),
        //        Isbn = Convert.ToChar(prDataRow["Isbn"])
        //    };
        //}

        #endregion

        #region GET APIs

        public List<string> GetAuthorNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT author_name FROM author", null);
            List<string> lcNames = new List<string>();
            Console.Write("GetAuthorNames called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsAuthor GetAuthor(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM author WHERE author_name = @Name", par);
            Console.Write("GetAuthor called" + "\n" + "\n");

            if (lcResult.Rows.Count > 0)
                return new clsAuthor()
                {
                    Name = (string)lcResult.Rows[0]["author_name"],
                    Email = (string)lcResult.Rows[0]["email_address"],
                    JoinDate = (DateTime)lcResult.Rows[0]["join_date"],
                    BookList = getAuthorBooks(Name)                             // issue here
                };
            else
                return null;
        }

        private List<clsBook> getAuthorBooks(string prName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", prName);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM book WHERE author_name = @Name", par);
            List<clsBook> lcBooks = new List<clsBook>();
            Console.Write("getAuthorBooks called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
            lcBooks.Add(formatBookData(dr));                                    // is called with author name,  maybe formating problem?
            return lcBooks;
        }

        //needs testing
        public List<string> GetOrderNumbers()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT order_number FROM order", null);
            List<string> lcNumbers = new List<string>();

            foreach (DataRow dr in lcResult.Rows)
                lcNumbers.Add((string)dr[0]);
            return lcNumbers;
        }

        //needs testing
        public clsOrder GetOrder(int Number)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Number", Number);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM order WHERE order_number = @Number", par);

            if (lcResult.Rows.Count > 0)
                return new clsOrder()
                {
                    Number = (int)lcResult.Rows[0]["order_number"],
                    Name = (string)lcResult.Rows[0]["customer_name"],
                    Email = (string)lcResult.Rows[0]["email_address"],
                    OrderDate = (DateTime)lcResult.Rows[0]["order_date"],
                    Price = (decimal)lcResult.Rows[0]["item_price"],
                    Quantity = (int)lcResult.Rows[0]["quantity"],
                    Isbn = (char)lcResult.Rows[0]["isbn_number"],
                };
            else
                return null;
        }


        #endregion

        #region PUT APIs

        public string PutAuthor(clsAuthor prAuthor)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE author SET email_address = @Email WHERE author_name = @Name",
                prepareAuthorParameters(prAuthor));

                if (lcRecCount == 1)
                    return "Author record updated";
                else
                    return "Unexpected author update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        #endregion

        #region POST APIs

        public string PostAuthor(clsAuthor prAuthor)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "INSERT INTO author (author_name, email_address, join_date) VALUES ( @Name, @Email, @JoinDate )",
                prepareAuthorParameters(prAuthor));

                if (lcRecCount == 1)
                    return "New author record created";
                else
                    return "Unexpected author addition count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        } 

        #endregion



    }
}
