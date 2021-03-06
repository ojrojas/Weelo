using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Favorites OWner Dto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class FavoritesOwner : BaseEntity, IAggregateRoot
    {
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
