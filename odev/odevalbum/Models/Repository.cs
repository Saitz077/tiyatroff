using Microsoft.EntityFrameworkCore;

namespace odevalbum.Models
{
    public class Repository
    {
        private static List<TabloSanat> _sanatAlbum=new List<TabloSanat>();
        private AppDbContext _dbContext;
        public List<TabloSanat> GetAll() => _sanatAlbum;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Add(TabloSanat tabloSanat)
        {
            _dbContext.Sanat.Add(tabloSanat);
            _dbContext.SaveChanges();
        }
        public void Remove(int id)
        {
            var hasAlbum=_sanatAlbum.FirstOrDefault(x=>x.Id==id);
            
            _sanatAlbum.Remove(hasAlbum);
        }
        public void Update(TabloSanat updateTablo)
        {
            var hasAlbum = _sanatAlbum.FirstOrDefault(x => x.Id == updateTablo.Id);
            if (hasAlbum == null)
            {
                throw new Exception($"bu id({updateTablo.Id})'ye sahip Albüm bulunmamaktadır.");
            }

            hasAlbum.No = updateTablo.No;
            hasAlbum.Tur = updateTablo.Tur;
            hasAlbum.SanatciBilgi = updateTablo.SanatciBilgi;
            hasAlbum.AlbumAdi = updateTablo.AlbumAdi;
            hasAlbum.Fiyat = updateTablo.Fiyat;
            hasAlbum.Yerli = updateTablo.Yerli;

            _dbContext.SaveChanges();
        }

    }

}
