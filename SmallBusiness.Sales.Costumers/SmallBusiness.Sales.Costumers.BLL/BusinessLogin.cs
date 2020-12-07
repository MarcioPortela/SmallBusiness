using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmallBusiness.Sales.Costumers.DAL;
using SmallBusiness.Sales.Costumers.Model;

namespace SmallBusiness.Sales.Costumers.BLL
{
    public class BusinessLogin
    {
        private RepositoryUserSys repositoryUserSys;

        public bool IsLoginValid(UserSys userSys)
        {
            repositoryUserSys = new RepositoryUserSys(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            UserSys userSysAux = repositoryUserSys.GetLogin(userSys);

            if (userSys != null && userSys.Id > 0)
                return true;
            else
                return false;
        }
    }
}
