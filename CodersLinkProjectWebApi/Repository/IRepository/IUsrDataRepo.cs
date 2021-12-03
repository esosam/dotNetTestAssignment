using CodersLinkProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApi.Repository.IRepository
{
    public interface IUsrDataRepo
    {
        ICollection<UsrData> GetUsrDatas();

        ICollection<UsrData> GetUsrFilterDatas(string lname, bool sortby);

        UsrData GetUsrData(int usrId);
        
        bool UsrDataExists(string email);

        bool UsrDataExists(int usrId);

        bool CreateUsrData(UsrData usrData);        

        bool UpdateUsrData(UsrData usrData);

        bool DeleteUsrData(UsrData usrData);

        bool Save();
    }
}
