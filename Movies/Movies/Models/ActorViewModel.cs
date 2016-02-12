namespace Movies.Models
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class ActorViewModel
    {
        public static Expression<Func<Actor,ActorViewModel>> FromActor
        {
            get
            {
                return actor => new ActorViewModel
                {
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    DOB = actor.DOB,
                    IsFemale = actor.IsFemale,
                    Id = actor.ActorId
                };
            }
        }

        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }

        public bool IsFemale { get; set; }

    }
}