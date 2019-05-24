namespace MediaOrganiser.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class MediaFile
    {
        [Key]
        public long FileID { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public string MediaFileType { get; set; }

        public string Comment { get; set; }
        [Required]
        public long? PlaylistID { get; set; }

        public long? CategoryID { get; set; }

        public long? ImageID { get; set; }

        [NotMapped]
        public virtual Category Category { get; set; }

        [NotMapped]
        public HttpPostedFileBase upload { get; set; }
        [NotMapped]
        public virtual ICollection<Image> Images { get; set; }
        [NotMapped]
        public virtual Playlist Playlist { get; internal set; }
    }
}
