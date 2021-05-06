using JobApp.Library.Internal.DataAccess;
using JobApp.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Library.DataAccess
{
    public class UserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            _config = config;
        }

        public List<UserModel> GetUserById(string Id)
        {
            // !NOTE implement interface instead of direct dependency
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "DefaultConnection");

            return output;
        }
    }
}
