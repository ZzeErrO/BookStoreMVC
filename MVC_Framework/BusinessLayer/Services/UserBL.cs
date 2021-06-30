using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelsLayer.Models;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL _userRL)
        {
            userRL = _userRL;
        }
        public bool Register(Register register)
        {
            return this.userRL.Register(register);
        }
        public bool Login(Login login)
        {
            return this.userRL.Login(login);
        }
    }
}
