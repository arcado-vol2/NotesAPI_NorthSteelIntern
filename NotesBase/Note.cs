using System;

namespace NotesBase
{
    public class Note
    {
        public Guid userID {  get; set; }
        public Guid ID { get; set; }
        public string head { get; set; }
        public string body { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
