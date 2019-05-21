namespace MediaOrganiser.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MediaEntities : DbContext
    {
        public MediaEntities()
            : base("name=MediaEntities")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MediaFile> MediaFiles { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.MediaFiles)
                .WithRequired(e => e.Playlist)
                .WillCascadeOnDelete(false);
            
                
        }
    }
}
