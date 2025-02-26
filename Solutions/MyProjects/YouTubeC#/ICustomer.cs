using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeC_
{
    internal interface ICustomer
    {
        string Name { get;  }
        int ID { get;  }
        void Details();
    }
}
