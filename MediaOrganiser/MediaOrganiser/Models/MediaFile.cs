namespace MediaOrganiser.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MediaFile
    {
        [Key]
        public long FileID { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        [Required]
        [StringLength(10)]
        public string MediaFileType { get; set; }

        public string Comment { get; set; }

        public long? PlaylistID { get; set; }

        public long? CategoryID { get; set; }

        public long? ImageID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Image Image { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
