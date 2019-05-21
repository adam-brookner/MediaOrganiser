using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public interface IMediaRepository
    {
        //Playlist CRUD
        IEnumerable<Playlist> GetAllPlaylists();
        Playlist GetPlaylistById(int PlaylistID);
        void AddPlaylist(Playlist playlist);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        IEnumerable<Playlist> GetPlaylistsByMediaFile(int FileID); //Only if a song can be in multiple playlists - else, I'll remove this or investigate further depending on time

        //MediaFiles CRUD
        IEnumerable<MediaFile> GetAllMediaFiles();
        MediaFile GetMediaFileById(int FileID);
        IEnumerable<MediaFile> GetMediaFilesByPlaylist(int PlaylistID);
        void AddMediaFile(MediaFile mediaFile);
        void UpdateMediaFile(MediaFile mediaFile);
        void DeleteMediaFile(MediaFile mediaFile);

        //Categories CRUD
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int CategoryID);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        //Images CRUD - Not 
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int ImageID);
        void AddImage(Image image);
        void UpdateImage(Image image);
        void DeleteImage(Image image);
    }
}
