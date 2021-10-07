using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagerTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime HiringDate { get; set; }
        public string Rank { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }   
    }
}
