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

        #region GET APIs
        public List<string> GetAuthorNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT author_name FROM author", null);
            List<string> lcNames = new List<string>();
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
            if (lcResult.Rows.Count > 0)
                return new clsAuthor()
                {
                    Name = (string)lcResult.Rows[0]["author_name"],
                    Email = (string)lcResult.Rows[0]["email_address"],
                    JoinDate = (DateTime)lcResult.Rows[0]["join_date"]
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
