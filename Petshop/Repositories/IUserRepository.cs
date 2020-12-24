using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public interface IUserRepository
    {
        public double GetBalance();
        public void ChangeBalance(double balance);
    }
}
