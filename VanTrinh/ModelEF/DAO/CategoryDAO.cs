using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        private VanTrinhContext db;

        public CategoryDAO()
        {
            db = new VanTrinhContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}
