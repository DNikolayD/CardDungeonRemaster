using System;

namespace Data.Entities.Common
{
    public class BaseDataEntity<T> : IBaseDataEntity<T>
    {

        public BaseDataEntity()
        {
            CreatedOn = DateTime.Now;
        }

        public T Id { get; init; }

        public DateTime CreatedOn { get; init; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsEdited { get; set; }

        public DateTime EditedOn { get; set; }
    }
}
