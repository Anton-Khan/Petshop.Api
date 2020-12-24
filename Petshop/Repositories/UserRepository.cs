using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private double _balance;
        public UserRepository()
        {
            _balance = 30000;
        }
        public void ChangeBalance(double balance)
        {
            _balance = balance;
        }
        public double GetBalance()
        {
            return _balance;
        }
    }
}
