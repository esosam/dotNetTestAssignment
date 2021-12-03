using CodersLinkProjectWebApi.Data;
using CodersLinkProjectWebApi.Models;
using CodersLinkProjectWebApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApi.Repository
{
    public class UsrDataRepo : IUsrDataRepo
    {
        private readonly AppDBContext _db;

        public UsrDataRepo(AppDBContext db)
        {
            _db = db;
        }

        public bool CreateUsrData(UsrData usrData)
        {
            _db.UsrDatas.Add(usrData);
            return Save();
        }

        public bool DeleteUsrData(UsrData usrData)
        {
            _db.UsrDatas.Remove(usrData);
            return Save();
        }

        public UsrData GetUsrData(int usrId)
        {
            return _db.UsrDatas.FirstOrDefault(d => d.Id == usrId);
        }

        public ICollection<UsrData> GetUsrDatas()
        {
            return _db.UsrDatas.OrderBy(d => d.UsrLastName).ToList();
        }

        public ICollection<UsrData> GetUsrFilterDatas(string lname, bool sortby)
        {
            //sortby DESC if true, ASC if false

            List<UsrData> tmpUsrData = new();

            if (string.IsNullOrWhiteSpace(lname))
            {
                tmpUsrData = _db.UsrDatas.OrderBy(d => d.UsrLastName).ToList();

                if (sortby)
                {
                    tmpUsrData = _db.UsrDatas.OrderByDescending(d => d.UsrLastName).ToList();
                }
            }
            else
            {
                tmpUsrData = _db.UsrDatas.Where(
                    d => d.UsrLastName.Trim().ToUpper() == lname.Trim().ToUpper()
                    ).OrderBy(d => d.UsrName).ToList();

                if (sortby)
                {
                    tmpUsrData = _db.UsrDatas.Where(
                    d => d.UsrLastName.Trim().ToUpper() == lname.Trim().ToUpper()
                    ).OrderByDescending(d => d.UsrName).ToList();
                }
            }

            return tmpUsrData;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUsrData(UsrData usrData)
        {
            _db.UsrDatas.Update(usrData);
            return Save();
        }

        public bool UsrDataExists(string email)
        {
            bool val = _db.UsrDatas.Any(d => d.UsrEmail.Trim().ToUpper() == email.Trim().ToUpper());
            return val;
        }

        public bool UsrDataExists(int usrId)
        {
            bool val = _db.UsrDatas.Any(d => d.Id == usrId);
            return val;
        }
    }
}
