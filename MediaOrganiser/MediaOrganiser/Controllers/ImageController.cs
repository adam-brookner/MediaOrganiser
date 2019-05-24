using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaOrganiser.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaOrganiser.Controllers
{
    public class ImageController : Controller
    {
        IMediaRepository mediaRepository = null;
        public ImageController(IMediaRepository mediaRepository)
        {
            this.mediaRepository = mediaRepository;
        }
        public ImageController()
        : this(new SQLMediaRepository())
        {

        }
        // GET: Image
        public ActionResult Index()
        {
            IEnumerable<Image> images = mediaRepository.GetAllImages();
            return View(images);
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            var details = mediaRepository.GetImageById(id);
            return View(details);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            Image image = new Image();
            return View(image);
        }

        // POST: Image/Create
        [HttpPost]
        public ActionResult Create(Image im)
        {
            string fileName = Path.GetFileNameWithoutExtension(im.ImageFile.FileName);
            string extension = Path.GetExtension(im.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            im.FilePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/") + fileName);
            im.ImageFile.SaveAs(fileName);
            using (MediaEntities db = new MediaEntities())
            {
                db.Images.Add(im);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        // GET: Image/Edit/5
       

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            Image image = mediaRepository.GetImageById(id);
            return View(image);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Image image = mediaRepository.GetImageById(id);
            try
            {
                // TODO: Add delete logic here
                mediaRepository.DeleteImage(image);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
