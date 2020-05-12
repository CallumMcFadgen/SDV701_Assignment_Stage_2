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

        public List<string> GetAuthorNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT author_name FROM author", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

    }
}
