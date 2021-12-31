using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Common
{
    public class ImagesDataEntity : BaseDataEntity<string>
    {
        public string Name { get; set; }
    }
}
