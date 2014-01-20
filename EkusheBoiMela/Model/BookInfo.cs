
using System;

namespace EkusheBoiMela.Model
{
    public class BookInfo
    {
        public long Isbn { get; set; }
        public string Title { get; set; }
        public string TitleInEnglish { get; set; }
        public string Author { get; set; }
        public string AuthorInEnglish { get; set; }
        public string Catagory { get; set; }
        public string Publisher { get; set; }
        public string PublisherInEnglish { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public byte[] CoverPhoto { get; set; }
        public string StallNo { get; set; }
        public float StallLat { get; set; }
        public float StallLong { get; set; }
        public DateTime CreationDate { get; set; }
    }
}