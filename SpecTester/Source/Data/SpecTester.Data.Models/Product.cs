namespace SpecTester.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SpecTester.Common;

    public class Product : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxProductNameLength)]
        public string Name { get; set; }

    }
}
