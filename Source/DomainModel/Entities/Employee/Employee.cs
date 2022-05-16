using System;

namespace DomainModel
{
    public class Employee : IEmployee
    {
        public String Name { get; set; }

        public RoleList Role { get; set; }

        public String ID { get; set; }

        public Employee() { }
    }
}
