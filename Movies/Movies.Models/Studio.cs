using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Studio
    {
        public int Id { get; set; }

        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }
    }
}