using System;

namespace Data.Common
{
    public interface IBaseDataEntity<T>
    {
        public T Id { get; init; }

        public DateTime CreatedOn { get; init; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsEdited { get; set; }

        public DateTime EditedOn { get; set; }

    }
}
