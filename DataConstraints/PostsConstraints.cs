using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConstraints
{
    public class PostsConstraints
    {
        public const int TitleMinLength = 3;

        public const int TitleMaxLength = 20;

        public const int ContentMinLength = 5;

        public const int ContentMaxLength = 200;
    }
}
