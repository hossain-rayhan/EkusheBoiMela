using System;

namespace EkusheBoiMela.Model.Entity
{
    public class Publisher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameInEnglish { get; set; }
        public string StallNo { get; set; }
        public float StallLat { get; set; }
        public float StallLong { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
