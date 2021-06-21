using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class SanPhamDAO
    {
        private VanTrinhContext db;

        public SanPhamDAO()
        {
            db = new VanTrinhContext();
        }

        public int Insert(Product emtity)
        {
            //var result = Find(emtity.ID);
            var result = FindTenSP(emtity.Name);
            if (result == null)
            {
                db.Products.Add(emtity);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }                    
        }

        public bool Delete(int id)
        {
            try
            {
                var sp = db.Products.Find(id);
                db.Products.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product Find(int id)
        {
            return db.Products.Find(id);
        }

        public Product FindTenSP(string tensp)
        {
            var result = db.Products.SingleOrDefault(x => x.Name.Contains(tensp));
            return result;
        }

        public List<Product> ListAll()
        {
            return db.Products.OrderBy(x => x.Quantity).OrderByDescending(x => x.UnitCost).ToList();
        }

        public List<Product> ListNewAll(int top)
        {
            return db.Products.Where(x => x.Status == "Hiển thị").OrderBy(x => x.Name).Take(top).ToList();
        }

        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IEnumerable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
    }
}
