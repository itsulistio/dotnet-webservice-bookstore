namespace WebServiceBookStore.Models
{
    public class Book
    {
        public int Id_Book { get; set; }
        public string ISBN { get; set; }
        public int Id_Publisher { get; set; }
        public int Id_Author { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
