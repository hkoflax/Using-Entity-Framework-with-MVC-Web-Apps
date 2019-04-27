using ComicBookShared.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data
{
    public class ComicBookArtistRepository : BaseRepository<ComicBookArtist>
    {
        public ComicBookArtistRepository(Context context) : base(context)
        {
        }

        public override ComicBookArtist Get(int id, bool includeRelatedEntities = true)
        {
            var comicBookArtists = Context.ComicBookArtists.AsQueryable();
            if (includeRelatedEntities)
            {
                comicBookArtists = comicBookArtists
                                     .Include(cba => cba.Artist)
                                     .Include(cba => cba.Role)
                                     .Include(cba => cba.ComicBook.Series);
            }
            return comicBookArtists
                 .Where(cba => cba.Id == (int)id)
                 .SingleOrDefault();
        }

        public override IList<ComicBookArtist> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
