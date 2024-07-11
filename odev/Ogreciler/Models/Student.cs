namespace Ogreciler.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string ad { get; set;}
        public string soyad { get; set; }
        public string dersTanimi { get; set; }
        public string sinif { get; set; }
        public int kredi { get; set; }
        public string sinavTarihi { get; set; }

        public int vizeNot { get; set; }
        public int finalNot { get; set; }
        public int ortalama { get; set; }
        public string harfNotu { get; set; }

       
    }
}
