namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common;

    public class EditProductAdminRequestModel
    {
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxProductNameLength)]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}
