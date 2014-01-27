using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lunchinator.Domain.BusinessApi;
using Lunchinator.Data.Entities;

namespace Lunchinator.Tests
{
    [TestClass]
    public class TestData
    {

        public static Lunch GetTestLunch()
        {
            return new Lunch {
                Businesses = GetTestItems(),
                Users = GetTestUsers()
            };
        }
        public static List<Business> GetTestItems()
        {
            return new List<Business>
                       {
                           new Business{Id="Lady in the Water"},
                           new Business{Id="Snakes on a Plane"},
                           new Business{Id="Just My Luck"},
                           new Business{Id="Superman Returns"},
                           new Business{Id="You, Me and Dupree"},
                           new Business{Id="The Night Listener"}


                       };
        } 

        public static List<User> GetTestUsers()
        {
            return new List<User>
                       {
                           new User
                               {
                                   UserId=1,
                                   FullName = "Lisa Rose",
                                   Ratings = new List<Rating>
                                                 {
                                                     new Rating {BusinessId="Lady in the Water", UserRating=2.5},
                                                     new Rating {BusinessId="Snakes on a Plane", UserRating=3.5},
                                                     new Rating {BusinessId="Just My Luck", UserRating=3.0},
                                                     new Rating {BusinessId="Superman Returns", UserRating=3.5},
                                                     new Rating {BusinessId="You, Me and Dupree", UserRating=2.5},
                                                     new Rating {BusinessId="The Night Listener", UserRating=3.0}
                                                 }

                               },
                           new User()
                               {
                                   UserId = 2,
                                   FullName = "Gene Seymour",
                                   Ratings = new List<Rating>
                                                 {
                                                     new Rating {BusinessId="Lady in the Water", UserRating=3.0},
                                                     new Rating {BusinessId="Snakes on a Plane", UserRating=3.5},
                                                     new Rating {BusinessId="Just My Luck", UserRating=1.5},
                                                     new Rating {BusinessId="Superman Returns", UserRating=5.0},
                                                     new Rating {BusinessId="The Night Listener", UserRating=3.0},
                                                     new Rating {BusinessId="You, Me and Dupree", UserRating=3.5}
                                                 }
                               },
                           new User
                               {
                                   UserId = 3,
                                   FullName = "Michael Phillips",
                                   Ratings = new List<Rating>
                                                 {
                                                     new Rating {BusinessId="Lady in the Water", UserRating= 2.5},
                                                     new Rating {BusinessId="Snakes on a Plane", UserRating= 3.0},
                                                     new Rating {BusinessId="Superman Returns", UserRating= 3.5},
                                                     new Rating {BusinessId="The Night Listener", UserRating= 4.0}
                                                 }
                               },
                        new User
                            {
                                UserId = 4,
                                FullName = "Claudia Puig",
                                Ratings = new List<Rating>
                                              {
                                                  new Rating  {BusinessId="Snakes on a Plane", UserRating= 3.5},
                                                  new Rating {BusinessId="Just My Luck", UserRating= 3.0},
                                                  new Rating {BusinessId="The Night Listener", UserRating= 4.5},
                                                  new Rating {BusinessId="Superman Returns", UserRating= 4.0},
                                                  new Rating {BusinessId="You, Me and Dupree", UserRating= 2.5}
                                                  
                                              }
                            },

                         new User
                            {
                                UserId = 5,
                                FullName = "Mick LaSalle",
                                Ratings = new List<Rating>
                                              {
                                                  new Rating {BusinessId="Lady in the Water", UserRating= 3.0},
                                                  new Rating {BusinessId="Snakes on a Plane", UserRating= 4.0},
                                                  new Rating {BusinessId="Just My Luck", UserRating= 2.0},
                                                  new Rating {BusinessId="Superman Returns", UserRating= 3.0},
                                                  new Rating {BusinessId="The Night Listener", UserRating= 3.0},
                                                  new Rating {BusinessId="You, Me and Dupree", UserRating= 2.0}
                                                  
                                              }
                            },
                        new User
                            {
                                UserId = 6,
                                FullName = "Jack Matthews",
                                Ratings = new List<Rating>
                                              {
                                                  new Rating {BusinessId="Lady in the Water", UserRating= 3.0},
                                                  new Rating {BusinessId="Snakes on a Plane", UserRating= 4.0},
                                                  new Rating {BusinessId="The Night Listener", UserRating= 3.0},
                                                  new Rating {BusinessId="Superman Returns", UserRating= 5.0},
                                                  new Rating {BusinessId="You, Me and Dupree", UserRating= 3.5},
                                                
                                                  
                                              }
                            },
                         new User
                             {
                                 UserId = 7,
                                 FullName = "Toby",
                                 Ratings = new List<Rating>
                                              {
                                                  new Rating {BusinessId="Snakes on a Plane", UserRating=4.5},
                                                  new Rating {BusinessId="You, Me and Dupree", UserRating=1.0},
                                                  new Rating {BusinessId="Superman Returns", UserRating=4.0}
                                                 
                                                
                                                  
                                              }
                             }
                       };
        }
    }
}
