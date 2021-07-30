using System;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Base Entities
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreateOn { get; set; }
        public virtual Guid ModifiedBy { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
    }
}
