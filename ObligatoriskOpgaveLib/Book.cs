using System.Xml.Linq;

namespace ObligatoriskOpgaveLib
{
    public class Book
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public int Price { get; set; }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title is null");
            }
            if (Title == "")
            {
                throw new ArgumentException("Title cannot be empty", "Title");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters", "Title");
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentException("Price cannot be negative", "Price");
            }
            if (Price <= 1200)
            {
                throw new ArgumentException("Price must be at least 1200", "Price");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }

    }
}