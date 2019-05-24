using MediaOrganiser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaOrganiser.Controllers
{
    public class MediaFilesController : Controller
    {
        private MediaEntities db = new MediaEntities();
        IMediaRepository mediaRepository = null;
        public MediaFilesController(IMediaRepository mediaRepository)
        {
            this.mediaRepository = mediaRepository;
        }
        public MediaFilesController()
        : this(new SQLMediaRepository())
        {

        }
        // GET: MediaFiles
        public ActionResult Index(string searchString)
        {
            var mediaFiles = from m in db.MediaFiles select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                mediaFiles = mediaFiles.Where(m => m.FileName.Contains(searchString));
            }
            return View(mediaFiles.ToList());
        }

        // GET: MediaFiles/Details/5
        public ActionResult Details(int id)
        {
            var details = mediaRepository.GetMediaFileById(id);
            return View(details);
        }

        // GET: MediaFiles/Create
        public ActionResult Create()
        {
            MediaFile mediaFile = new MediaFile();
            return View(mediaFile);
        }

        // POST: MediaFiles/Create
        [HttpPost]
        public ActionResult Create(MediaFile mediafile)
        {
            string fileName = Path.GetFileNameWithoutExtension(mediafile.upload.FileName);
            string extension = Path.GetExtension(mediafile.upload.FileName);
            fileName = fileName + extension;
            mediafile.FilePath = "~/Music/" + fileName;
            mediafile.MediaFileType = extension;
            fileName = Path.Combine(Server.MapPath("~/Music/") + fileName);
            mediafile.upload.SaveAs(fileName);
            
            using (MediaEntities db = new MediaEntities())
            {
                db.MediaFiles.Add(mediafile);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        // GET: MediaFiles/Edit/5
        public ActionResult Edit(int id)
        {
            MediaFile mediaFile = mediaRepository.GetMediaFileById(id);
            return View(mediaFile);
        }

        // POST: MediaFiles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MediaFile mediaFile)
        {
            try
            {
                // TODO: Add update logic here
                mediaRepository.UpdateMediaFile(mediaFile);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaFiles/Delete/5
        public ActionResult Delete(int id)
        {
            MediaFile mediaFile = mediaRepository.GetMediaFileById(id);

            return View(mediaFile);
        }

        // POST: MediaFiles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MediaFile mediaFile)
        {
            try
            {
                // TODO: Add delete logic here
                mediaRepository.DeleteMediaFile(mediaFile);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
