using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IBaseDto<T>
    {
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsEdited { get; set; }

        public DateTime EditedOn { get; set; }
    }
}
