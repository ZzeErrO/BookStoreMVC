using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        bool Register(Register register);
        bool Login(Login login);
    }
}
