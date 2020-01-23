using System;
using System.ComponentModel.DataAnnotations;

namespace Dare.IModel.Base
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
