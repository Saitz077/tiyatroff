using Ogreciler.Models;

namespace Ogreciler.Models
{
    public class OgrenciRepository
    {
        private static List<Student>  _ogrenci=new List<Student>() {
       /* new() { Id = 1, ad = "Mehmet Sait", soyad = "ÖZMEN", sinif = "2", dersTanimi = "OOP", kredi = 4, sinavTarihi = "17.04.2023", vizeNot = 45, finalNot = 55, ortalama = 51, harfNotu = "DD" },
        new () { Id = 2, ad = "Ahmmet", soyad = "ÖN", sinif = "3", dersTanimi = "Sistem Programlama", kredi = 6, sinavTarihi = "15.04.2023", vizeNot = 65, finalNot = 55, ortalama = 51, harfNotu = "DD" },
        new () { Id = 3, ad = "Mehmet", soyad = "UZUN", sinif = "3", dersTanimi = "Veri Tabanı", kredi = 6, sinavTarihi = "16.04.2023", vizeNot = 85, finalNot = 55, ortalama = 51, harfNotu = "DD" },
        new() { Id = 4, ad = "Cem", soyad = "Cs", sinif = "4", dersTanimi = "MAchine Learning", kredi = 7, sinavTarihi = "18.04.2023", vizeNot = 55, finalNot = 55, ortalama = 51, harfNotu = "DD" },
        new() { Id = 5, ad = "Emre", soyad = "ÖZ", sinif = "1", dersTanimi = "Mat1", kredi = 4, sinavTarihi = "18.04.2023", vizeNot = 75, finalNot = 85, ortalama = 51, harfNotu = "DD" }
        */};
        public List<Student> GetAll() => _ogrenci;

        public void Add(Student student) => _ogrenci.Add(student);

        public void Remove(int id)
        {
            var hasStudent = _ogrenci.FirstOrDefault(x => x.Id == id);
            if(hasStudent == null) 
            {
                throw new Exception($"bu numaraya({id}) ait öğrenci bulunmamaktadır");
            }
            _ogrenci.Remove(hasStudent);
        }

        public void Update(Student updateStudent) 
        {
            var hasStudent = _ogrenci.FirstOrDefault(x => x.Id== updateStudent.Id);
            if (hasStudent == null)
            {
                throw new Exception($"bu numaraya({updateStudent.Id}) ait öğrenci bulunmamaktadır");
            }
            hasStudent.ad=updateStudent.ad;
            hasStudent.soyad=updateStudent.soyad;
            hasStudent.sinif=updateStudent.sinif;
            hasStudent.dersTanimi=updateStudent.dersTanimi;
            hasStudent.kredi=updateStudent.kredi;
            hasStudent.vizeNot=updateStudent.vizeNot;
            hasStudent.finalNot=updateStudent.finalNot;
            hasStudent.ortalama=updateStudent.ortalama;
            hasStudent.harfNotu=updateStudent.harfNotu;

            var index = _ogrenci.FindIndex(x => x.Id == updateStudent.Id);
            _ogrenci[index] = hasStudent;

        }
    }
}
