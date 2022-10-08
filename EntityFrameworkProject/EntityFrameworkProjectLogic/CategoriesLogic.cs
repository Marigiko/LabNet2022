using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProjectLogic
{
    public class CategoriesLogic : BaseLogic, ICRUDLogic<Categories>
    {
        public void Add(Categories campo)
        {
            context.Categories.Add(campo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryAEliminar = context.Categories.Find(id);

            context.Categories.Remove(categoryAEliminar);

            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories campo)
        {
            var categoryAActualizar = context.Categories.Find(campo.CategoryID);

            categoryAActualizar.CategoryName = campo.CategoryName;

            context.SaveChanges();
        }
    }
}
