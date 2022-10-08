using EntityFrameworkMVC.Models;
using EntityFrameworkProjectEntities;
using EntityFrameworkProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesLogic category = new CategoriesLogic();

        // GET: Category
        public ActionResult Index()
        {
            List<Categories> categories = category.GetAll();

            List<CategoryView> categoryView = categories.Select(c => new CategoryView
            {
                id = c.CategoryID,
                name = c.CategoryName,
                products = c.Products.ToList(),
            }).ToList();

            return View(categoryView);
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryView categoryView)
        {
            try
            {
                Categories categoryEntity = new Categories{ CategoryName = categoryView.name };

                category.Add(categoryEntity);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        // Tengo problemas con el borrado en cascada, nose como hacerlo :c
        public ActionResult Delete(int id)
        {
            try
            {
                category.Delete(id);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
    }
}