using System.Collections.Generic;

namespace DependencyInjection.Services
{
    public class Gender
    {
        public Gender(List<string> values)
        {
            Values = values;
        }

        public List<string> Values { get; }
    }
}
