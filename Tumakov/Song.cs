using System;
namespace Tumakov
{
    public class Song
    {
        public Song()
        {
            Name = null;
            Author = null;
            Prev = null;
        }
        public Song(string name, string author)
        {
            this.Name = name;
            this.Author = author;
            this.Prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            this.Name = name;
            this.Author = author;
            this.Prev = prev;
        }
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Prev { get; set; }
        public void Title()
        {
            Console.WriteLine($"Название: {Name}, Автор: {Author}");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Song))
            {
                return false;
            }
            Song other = (Song)obj;
            return other.Name == Name & other.Author == Author;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Author);
        }
    }
}
