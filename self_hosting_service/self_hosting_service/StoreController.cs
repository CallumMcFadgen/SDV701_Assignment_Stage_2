using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http.Cors;

namespace self_hosting_service
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*")]

    public class StoreController : System.Web.Http.ApiController
    {
        #region PARAMETER CONFIGURATION

        private Dictionary<string, object> prepareAuthorParameters(clsAuthor Author)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("Name", Author.Name);
            par.Add("Email", Author.Email);
            par.Add("JoinDate", Author.JoinDate);
            return par;
        }

        private Dictionary<string, object> prepareBookParameters(clsBook Book)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("Isbn", Book.Isbn);
            par.Add("Type", Book.Type);
            par.Add("Title", Book.Title);
            par.Add("Desc", Book.Desc);
            par.Add("Price", Book.Price);
            par.Add("Quantity", Book.Quantity);
            par.Add("EditDate", Book.EditDate);
            par.Add("Genre", Book.Genre);
            par.Add("Category", Book.Category);
            par.Add("AuthorName", Book.AuthorName);
            return par;
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder Order)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(6);
            par.Add("Name", Order.Name);
            par.Add("Email", Order.Email);
            par.Add("OrderDate", Order.OrderDate);
            par.Add("Price", Order.Price);
            par.Add("Quantity", Order.Quantity);
            par.Add("Isbn", Order.Isbn);
            return par;
        }

        private Dictionary<string, object> prepareDeleteBookParameters(string prIsbn, string prAuthorName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("Isbn", prIsbn);
            par.Add("AuthorName", prAuthorName);
            return par;
        }

        private Dictionary<string, object> prepareDeleteOrderParameters(string prNumber)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("Number", prNumber);
            return par;
        }

        #endregion

        #region DATA FORMATTING

        private clsBook formatBookData(DataRow DataRow)
        {
            Console.Write("formatBookData called" + "\n" + "\n");
            return new clsBook()
            {
                Isbn = Convert.ToString(DataRow["isbn_number"]),
                Type = Convert.ToString(DataRow["type"]),
                Title = Convert.ToString(DataRow["title"]),
                Desc = DataRow["Description"] is DBNull ? null : Convert.ToString(DataRow["description"]),
                Price = Convert.ToDecimal(DataRow["price"]),
                Quantity = Convert.ToInt32(DataRow["quantity"]),
                EditDate = Convert.ToDateTime(DataRow["edit_date"]),
                Genre = DataRow["Genre"] is DBNull ? null : Convert.ToString(DataRow["genre"]),
                Category = DataRow["Category"] is DBNull ? null : Convert.ToString(DataRow["category"]),
                AuthorName = Convert.ToString(DataRow["author_name"])
            };
        }

        private clsOrder formatOrderData(DataRow DataRow)
        {
            Console.Write("formatOrderData called" + "\n" + "\n");
            return new clsOrder()
            {
                Number = Convert.ToInt32(DataRow["order_number"]),
                Name = Convert.ToString(DataRow["customer_name"]),
                Email = Convert.ToString(DataRow["email_address"]),
                OrderDate = Convert.ToDateTime(DataRow["order_date"]),
                Price = Convert.ToDecimal(DataRow["item_price"]),
                Quantity = Convert.ToInt32(DataRow["quantity"]),
                Isbn = Convert.ToString(DataRow["isbn_number"])
            };
        }

        #endregion

        #region GET APIs

        public List<string> GetAuthorNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT author_name FROM author ORDER BY author_name ASC", null);
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
                    BookList = getAuthorBooks(Name)
                };
            else
                return null;
        }

        public clsBook GetBook(string Isbn)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Isbn", Isbn);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM book WHERE isbn_number = @Isbn", par);
            Console.Write("GetBook called" + "\n" + "\n");

            if (lcResult.Rows.Count > 0)
                return new clsBook()
                {
                    Isbn = (string)lcResult.Rows[0]["isbn_number"],
                    Type = (string)lcResult.Rows[0]["type"],
                    Title = (string)lcResult.Rows[0]["title"],
                    Desc = (string)lcResult.Rows[0]["description"],
                    Price = (decimal)lcResult.Rows[0]["price"],
                    Quantity = (int)lcResult.Rows[0]["quantity"],
                    EditDate = (DateTime)lcResult.Rows[0]["edit_date"],
                    Genre = (string)lcResult.Rows[0]["genre"],
                    Category = (string)lcResult.Rows[0]["category"],
                    AuthorName = (string)lcResult.Rows[0]["author_name"]
                };
            else
                return null;
        }

        public List<clsBook> getAuthorBooks(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM book WHERE author_name = @Name ORDER BY title ASC", par);
            List<clsBook> lcBooks = new List<clsBook>();
            Console.Write("getAuthorBooks called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
            lcBooks.Add(formatBookData(dr));
            return lcBooks;
        }

        public List<clsOrder> getOrders()
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM book_order ORDER BY order_date DESC", null);
            List<clsOrder> lcOrders = new List<clsOrder>();
            Console.Write("getOrders called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
                lcOrders.Add(formatOrderData(dr));
            return lcOrders;
        }

        public List<clsOrder> GetOrderDetails()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM book_order ORDER BY order_date ASC", null);
            List<clsOrder> lcDetails = new List<clsOrder>();
            Console.Write("getBookOrderDetails called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
                lcDetails.Add((clsOrder)dr[0]);
            return lcDetails;
        }

        public clsOrder GetBookOrder(string Number)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Number", Number);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM book_order WHERE order_number = @Number", par);
            Console.Write("getBookOrder called" + "\n" + "\n");

            if (lcResult.Rows.Count > 0)
                return new clsOrder()
                {
                    Number = (int)lcResult.Rows[0]["order_number"],
                    Name = (string)lcResult.Rows[0]["customer_name"],
                    Email = (string)lcResult.Rows[0]["email_address"],
                    OrderDate = (DateTime)lcResult.Rows[0]["order_date"],
                    Price = (decimal)lcResult.Rows[0]["item_price"],
                    Quantity = (int)lcResult.Rows[0]["quantity"],
                    Isbn = (string)lcResult.Rows[0]["isbn_number"]
                };
            else
                return null;
        }

        #endregion

        #region PUT APIs

        public string PutAuthor(clsAuthor Author)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE author SET email_address = @Email WHERE author_name = @Name",
                prepareAuthorParameters(Author));

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

        public string PutBook(clsBook Book)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE book SET " +
                "type = @Type, " +
                "title = @Title, " +
                "description = @Desc, " +
                "price = @Price, " +
                "quantity = @Quantity, " +
                "edit_date = @EditDate, " +
                "genre = @Genre, " +
                "category = @Category, " +
                "author_name = @AuthorName " +
                "WHERE isbn_number = @Isbn",
                prepareBookParameters(Book));
                if (lcRecCount == 1)
                    return "One book updated";
                else
                    return "Unexpected book update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutBookQuantity(clsBook Book)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE book SET quantity = quantity - @Quantity, edit_date = @EditDate WHERE isbn_number = @Isbn and quantity >= @Quantity",
                prepareBookParameters(Book));
                if (lcRecCount == 1)
                    return "Success";
                else
                    return "Failure";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        #endregion

        #region POST APIs

        public string PostAuthor(clsAuthor Author)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "INSERT INTO author (author_name, email_address, join_date) VALUES ( @Name, @Email, @JoinDate )",
                prepareAuthorParameters(Author));

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

        public string PostBook(clsBook Book)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO book " +
                "(isbn_number, type, title, description, price, quantity, edit_date, genre, category, author_name) " +
                "VALUES (@Isbn, @Type, @Title, @Desc, @Price, @Quantity, @EditDate, @Genre, @Category, @AuthorName)",
                prepareBookParameters(Book));
                if (lcRecCount == 1)
                    return "One book added";
                else
                    return "Unexpected book addition count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostOrder(clsOrder Order)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "INSERT INTO book_order (customer_name, email_address, order_date, item_price, quantity, isbn_number)" +
                "VALUES ( @Name, @Email, @OrderDate, @Price, @Quantity, @Isbn )",
                prepareOrderParameters(Order));

                if (lcRecCount == 1)
                    return "New order record created";
                else
                    return "Unexpected order addition count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        #endregion

        #region DELETE APIs

        public string DeleteBook(string Isbn, string AuthorName)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM book WHERE isbn_number = @Isbn AND author_name = @AuthorName",
                    prepareDeleteBookParameters(Isbn, AuthorName));

                if (lcRecCount == 1)
                    return "One book deleted";
                else
                    return "Unexpected book deletion count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(string Number)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM book_order WHERE order_number = @Number",
                    prepareDeleteOrderParameters(Number));

                if (lcRecCount == 1)
                    return "One order deleted";
                else
                    return "Unexpected order deletion count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        #endregion
    }
}
