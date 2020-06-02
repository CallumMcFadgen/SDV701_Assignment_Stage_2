using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_hosting_service
{
    #region AUTHOR DTO

    public class clsAuthor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        //public List<clsAllBooks> BooksList { get; set; }
    }

    #endregion
}
