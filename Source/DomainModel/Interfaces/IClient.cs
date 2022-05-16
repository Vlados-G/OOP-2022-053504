using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public enum ClientStatus
    {
        NotApproved,
        Аpproved,
        Denied
    }

    public interface IClient: IUser
    {
        ClientStatus Status { get; set; }
        String Telephone { get; set; }
        String Mail { get; set; }
    }
}
