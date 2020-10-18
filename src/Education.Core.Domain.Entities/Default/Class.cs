using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Entities.Default
{
    public class Class : DomainEntity
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }

        public Class()
        {
        }
    }
}
