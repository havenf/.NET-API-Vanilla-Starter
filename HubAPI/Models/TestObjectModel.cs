using System;

namespace HubAPI.Models
{
    public class TestObjectModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}
