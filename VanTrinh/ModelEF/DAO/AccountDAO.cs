using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class AccountDAO
    {
        private VanTrinhContext db;

        public AccountDAO()
        {
            db = new VanTrinhContext();
        }

        public string login(string Name, string Pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(Name) && x.Password.Contains(Pass));
            if (result == null)
            {
                return null;
            }
            else
            {
                return result.Status;
            }
        }
        public int Insert(UserAccount emtityNV)
        {
            //var result = Find(emtityNV.ID);
            var result = FindTenDN(emtityNV.UserName);
            if (result == null)
            {
                db.UserAccounts.Add(emtityNV);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public bool Delete(string tendn)
        {
            try
            {
                var nv = FindTenDN(tendn);
                db.UserAccounts.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserAccount Find(int id)
        {
            return db.UserAccounts.Find(id);
        }

        public UserAccount FindTenDN(string tendn)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(tendn));
            return result;
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IEnumerable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
