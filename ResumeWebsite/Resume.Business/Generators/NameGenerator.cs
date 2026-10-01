using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Business.Generators
{
    class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
