
using System;

namespace EkusheBoiMela.Model.Entity
{
    public class Book
    {
        public long Isbn { get; set; }
        public string Title { get; set; }
        public string TitleInEnglish { get; set; }
        public long AuthorId { get; set; }
        public long CatagoryId { get; set; }
        public long PublisherId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] CoverPhoto { get; set; }

        public virtual Author Author { get; set; }
        public virtual Catagory Catagory { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
