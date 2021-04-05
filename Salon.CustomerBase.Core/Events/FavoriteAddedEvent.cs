using Salon.CustomerBase.Core.SharedKernel;
using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Core.Events
{
    public class FavoriteAddedEvent : BaseDomainEvent
    {
        public int FavoriteId { get; }
        public Favorite Entry { get; }

        public FavoriteAddedEvent(int favoriteId, Favorite entry)
        {
            FavoriteId = favoriteId;
            Entry = entry;
        }
    }
}
