using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaOrganiser.Models
{
    public class SQLMediaRepository : IMediaRepository
    {
        //Creates an instance of MediaEntities
        MediaEntities mediaDB = new MediaEntities();
        
        //Category CRUD
        public void AddCategory(Category category)
        {
            mediaDB.Categories.Add(category);
            mediaDB.SaveChanges();
        }
        //Updates from temporary object
        public void UpdateCategory(Category category)
        {
            Category tmpCategory = mediaDB.Categories.Single(c => c.CategoryID == category.CategoryID);
            tmpCategory.Name = category.Name;
            tmpCategory.Comment = category.Comment;
            mediaDB.SaveChanges();
        }
        IEnumerable<Category> IMediaRepository.GetAllCategories()
        {
            return mediaDB.Categories.ToList();
        }
        public void DeleteCategory(Category category)
        {
            mediaDB.Categories.Remove(category);
            mediaDB.SaveChanges();
        }
        Category IMediaRepository.GetCategoryById(int CategoryID)
        {
            return mediaDB.Categories.Single(c => c.CategoryID == CategoryID);
        }
        //End Category CRUD
        //Images CRUD
        IEnumerable<Image> IMediaRepository.GetAllImages()
        {
            return mediaDB.Images.ToList();
        }

        Image IMediaRepository.GetImageById(int ImageID)
        {
            return mediaDB.Images.Single(i => i.ImageID == ImageID);
        }

        public void UpdateImage(Image image)
        {
            Image tmpImage = mediaDB.Images.Single(i => i.ImageID == image.ImageID);
            tmpImage.FilePath = image.FilePath;
            tmpImage.Name = image.Name;
            tmpImage.ImageFile = image.ImageFile;
            mediaDB.SaveChanges();
        }
        public void DeleteImage(Image image)
        {
            mediaDB.Images.Remove(image);
            mediaDB.SaveChanges();
              
        }
        //End Image CRUD
        //MediaFiles CRUD
        public void AddMediaFile(MediaFile mediaFile)
        {
            mediaDB.MediaFiles.Add(mediaFile);
            mediaDB.SaveChanges();
        }

        public void DeleteMediaFile(MediaFile mediaFile)
        {
            mediaDB.MediaFiles.Remove(mediaFile);
            mediaDB.SaveChanges();
        }

        IEnumerable<MediaFile> IMediaRepository.GetAllMediaFiles()
        {
            return mediaDB.MediaFiles.ToList();
        }

        MediaFile IMediaRepository.GetMediaFileById(int FileID)
        {
            return mediaDB.MediaFiles.Single(c => c.FileID == FileID);
        }

        public void UpdateMediaFile(MediaFile mediaFile)
        {
            MediaFile tmpMediaFile = mediaDB.MediaFiles.Single(c => c.FileID == mediaFile.FileID);
            tmpMediaFile.FileName = mediaFile.FileName;
            tmpMediaFile.Comment = mediaFile.Comment;
            //tmpMediaFile.CategoryID = mediaFile.CategoryID;
            //tmpMediaFile.PlaylistID = mediaFile.PlaylistID;
            //tmpMediaFile.ImageID = mediaFile.ImageID;
            mediaDB.SaveChanges();
        }
        //End Media CRUD
        public void AddPlaylist(Playlist playlist)
        {
            mediaDB.Playlists.Add(playlist);
            mediaDB.SaveChanges();
        }

        public void DeletePlaylist(Playlist playlist)
        {
            mediaDB.Playlists.Remove(playlist);
            mediaDB.SaveChanges();
        }

        IEnumerable<Playlist> IMediaRepository.GetAllPlaylists()
        {
            return mediaDB.Playlists.ToList();
        }

        Playlist IMediaRepository.GetPlaylistById(int PlaylistID)
        {
            return mediaDB.Playlists.Single(c => c.PlaylistID == PlaylistID);
        }

        IEnumerable<MediaFile> IMediaRepository.GetMediaFilesByPlaylist(int PlaylistID)
        {
            return mediaDB.MediaFiles.Where(p => p.PlaylistID == PlaylistID).ToList();
        }

        void IMediaRepository.UpdatePlaylist(Playlist playlist)
        {
            Playlist tmpPlaylist = mediaDB.Playlists.Single(p => p.PlaylistID == playlist.PlaylistID);
            tmpPlaylist.Name = playlist.Name;
            tmpPlaylist.Comment = playlist.Comment;
        }

        
    }
}