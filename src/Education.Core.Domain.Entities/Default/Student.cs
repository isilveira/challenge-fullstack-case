using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Entities.Default
{
    public class Student : DomainEntity
    {
        public int StudentID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int ClassID { get; set; }
        public Class Class { get; set; }
        public Student()
        {
        }
    }
}
