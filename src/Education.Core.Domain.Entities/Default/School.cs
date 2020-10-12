using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Entities.Default
{
    public class School : DomainEntity
    {
        public int SchoolID { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; }
        public School()
        {
        }
    }
}
