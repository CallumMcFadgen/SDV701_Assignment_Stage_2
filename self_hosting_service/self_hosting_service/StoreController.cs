using System;
using System.Collections.Generic;
using System.Data;

namespace self_hosting_service
{
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

        private Dictionary<string, object> prepareBookParameters(clsBook prBook)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("Isbn", prBook.Isbn);
            par.Add("Type", prBook.Type);
            par.Add("Title", prBook.Title);
            par.Add("Desc", prBook.Desc);
            par.Add("Price", prBook.Price);
            par.Add("Quantity", prBook.Quantity);
            par.Add("EditDate", prBook.EditDate);
            par.Add("Genre", prBook.EditDate);
            par.Add("Category", prBook.Category);
            par.Add("AuthorName", prBook.AuthorName);
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
                    BookList = getAuthorBooks(Name)
                };
            else
                return null;
        }

        public List<clsBook> getAuthorBooks(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM book WHERE author_name = @Name", par);
            List<clsBook> lcBooks = new List<clsBook>();
            Console.Write("getAuthorBooks called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
            lcBooks.Add(formatBookData(dr));
            return lcBooks;
        }

        public List<int> GetBookOrderDetails()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT order_number FROM book_order", null);
            List<int> lcDetails = new List<int>();
            Console.Write("getBookOrderDetails called" + "\n" + "\n");

            foreach (DataRow dr in lcResult.Rows)
                lcDetails.Add((int)dr[0]);
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

        public string PostBook(clsBook prBook)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO book " +
                "(isbn_number, type, title, description, price, quantity, edit_date, genre, category, author_name) " +
                "VALUES (@Isbn, @Type, @Title, @Desc, @Price, @Quantity, @EditDate, @Genre, @Category, @AuthorName)",
                prepareBookParameters(prBook));
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

        #endregion



    }
}
