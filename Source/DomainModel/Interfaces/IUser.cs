using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IUser
    {
        String ID { get; set; }

        String Name { get; set; }

        RoleList Role { get; set; }


    }
}
