using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BbDatabase
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
