using MongoDB.Driver;
using Salon.WalletBase.API.Entities;
using System.Collections.Generic;

namespace Salon.WalletBase.API.Data
{
    public class SalonDBContextSeed
    {
        public static void SeedData(IMongoCollection<BeautySalon> BeautySalontCollection)
        {
            bool BeautySalon = BeautySalontCollection.Find(p => true).Any();
            if (!BeautySalon)
            {
                BeautySalontCollection.InsertManyAsync(GetPreconfiguredBeautySalons());
            }
        }

        private static IEnumerable<BeautySalon> GetPreconfiguredBeautySalons()
        {
            return new List<BeautySalon>()
            {
                new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"
                    
                },
               new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"

                },
               new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"

                },
               new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"

                },
               new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"

                },
                new BeautySalon()
                {
                    SalonName = "Bjay Beauty Parlor",
                     CategoryId = "3",
                     LocationId = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                     Description = "This is the best salon found in the Bay Area",
                     Comments = "Check it out"

                },
            };
        }
    }
}
