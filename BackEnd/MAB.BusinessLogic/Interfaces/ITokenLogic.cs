using MAB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.BusinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
