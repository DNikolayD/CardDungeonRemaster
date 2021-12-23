using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class CardTypesDto : BaseDto<int>
    {
        public string Name { get; set; }
    }
}
