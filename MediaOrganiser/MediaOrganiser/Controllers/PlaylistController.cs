using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaOrganiser.Models;

namespace MediaOrganiser.Controllers
{
    public class PlaylistController : Controller
    {
        IMediaRepository mediaRepository = null;

        public PlaylistController(IMediaRepository mediaRepository)
        {
            this.mediaRepository = mediaRepository;
        }
        public PlaylistController()
        :this(new SQLMediaRepository())
        {

        }
        
        // GET: Playlist
        public ActionResult Index()
        {
            IEnumerable<Playlist> playlists = mediaRepository.GetAllPlaylists();
            return View(playlists);
        }

        // GET: Playlist/Details/5
        public ActionResult Details(int id)
        {
            var result = mediaRepository.GetPlaylistById(id);
            ViewBag.MediaFiles = mediaRepository.GetMediaFilesByPlaylist(id);
            return View(result);
        }

        // GET: Playlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Edit/5
        public ActionResult Edit(int id)
        {
            Playlist playlist = mediaRepository.GetPlaylistById(id);
            return View(playlist);
        }

        // POST: Playlist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Playlist playlist)
        {
            try
            {
                // TODO: Add update logic here

                mediaRepository.UpdatePlaylist(playlist);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetMediaFilesForPlaylist(List<MediaFile> mediaFiles)
        {
            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                return PartialView("~/Views/MediaFiles/PartialMediaFilesList.cshtml", mediaFiles);

            }
            else
            {
                ContentResult cr = new ContentResult();
                cr.Content = "There are no songs in this playlist";
                return cr;
            }
        }
    }
}
