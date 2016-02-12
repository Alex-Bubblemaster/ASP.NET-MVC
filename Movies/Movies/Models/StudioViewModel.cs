using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Movies.Models
{
    public class StudioViewModel
    {
        public static Expression<Func<Studio, StudioViewModel>> FromStudio
        {
            get
            {
                return studio => new StudioViewModel
                {
                    Name = studio.Name,
                    Address = studio.Address,
                    Id = studio.Id
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}