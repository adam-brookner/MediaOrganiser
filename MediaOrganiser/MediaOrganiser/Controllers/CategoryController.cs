using MediaOrganiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaOrganiser.Controllers
{
    public class CategoryController : Controller
    {
        private MediaEntities db = new MediaEntities();
        IMediaRepository mediaRepository = null;
        public CategoryController(IMediaRepository mediaRepository)
        {
            this.mediaRepository = mediaRepository;
        }
        public CategoryController()
        :this(new SQLMediaRepository())
        {

        }
        // GET: Category
        public ActionResult Index(string searchString)
        {
            var categories = from c in db.Categories select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c => c.Name.Contains(searchString));
            }
            ViewBag.Message = "Categories List";
            return View(categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var details = mediaRepository.GetCategoryById(id);
            return View(details);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here

                mediaRepository.AddCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = mediaRepository.GetCategoryById(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                // TODO: Add update logic here
                mediaRepository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = mediaRepository.GetCategoryById(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Category category = mediaRepository.GetCategoryById(id);
            try
            {
                // TODO: Add delete logic here
                mediaRepository.DeleteCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
