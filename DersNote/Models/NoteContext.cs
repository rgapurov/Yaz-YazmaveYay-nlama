using Microsoft.EntityFrameworkCore;

namespace DersNote.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {

        }

        // referans gorunen ısımler(s'li olanlar) verıtabanında tablo adları olut
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
